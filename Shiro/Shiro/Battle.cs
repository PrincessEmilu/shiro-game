using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shiro
{
    //Handles battlestes
    enum BattleState
        {
            Idle,
            Fight,
            Victory,
            Death,
            RanAway
        }

    class Battle
    {
        //Fields
        protected int timer;
        protected int attackTick;
        protected int keySpeed;
        protected int arrowPosition;
        protected int timerOriginal; //To help measure the time passed
        protected int chance;
        protected Random rng;
        protected bool failedRun;
        protected bool success;
        protected string runText;

        //References to player and enemy in battle
        protected Player player;
        protected Enemy enemy;

        //Resources
        protected SpriteFont font;
        protected Texture2D UpArrow;
        protected Texture2D DownArrow;
        protected Texture2D LeftArrow;
        protected Texture2D RightArrow;
        protected Texture2D hitboxTexture;
        protected Texture2D healthBoxTexture;
        
        //Keyboard
        protected KeyboardState kbState;
        protected KeyboardState pbState;

        //List of keys
        protected List<AttackKey> listKeys;
        protected Queue<Keys> queueAttacks;
        protected ImportAttackPatterns patternReader;

        //The hitbox for blocking enemy attacks
        protected Rectangle hitbox;

        //Location on battlescreen to draw the enemy and the player
        protected Point playerPosition;
        protected Point enemyPosition;


        //Battle starts out idle
        protected BattleState battleState = BattleState.Idle;

        //Properties
        //Properties that Game1 can check to know how to handle the current battle when it ends.
        public bool Victory { get; private set; }
        public bool GameOver { get; private set; }
        public bool RanAway{ get;  private set; }
        public Enemy currentEnemy
        {
            get { return enemy; }
        }

        //Constructor
        //The battle class will need a reference to an enemy and the player; it may also need to know other things, such as
        //the previous locations of the player and the enemies that were on the level.
        public Battle(KeyboardState kbState, KeyboardState pbState, SpriteFont font, Texture2D UpArrow, Texture2D DownArrow, Texture2D LeftArrow, Texture2D RightArrow,
            Texture2D hitboxTexture, Texture2D healthBox, Player player, Enemy enemy, int keySpeed, int runAwayChance, Random rng)
        {
            //The stars of the show...
            this.player = player;
            this.enemy = enemy;


            //attackTick is the number of frames before a new enemy attack will be created.
            //Although here it is a constant, it can be changed with different enemies.
            timer = 0;
            attackTick = 25;
            arrowPosition = 1;
            timerOriginal = 0;

            chance = runAwayChance;
            this.rng = rng;
            failedRun = false;
            success = false;
            runText = "Run Away Attempt Failed. Shiro has lost 10 Stamina. ";

            //Also hardcoded for now, eventually given by enemy?
            this.keySpeed = keySpeed;

            //Positions to draw player and enemy
            player.PrevPos = player.Position;

            player.X = 100;
            player.Y = 200;
            enemy.X = 700;
            enemy.Y = 200;

            //listKeys holds the key attack objects. queueAttacks hold the attack pattern from the enemy in battle.
            //For now, it is a hard-coded value.
            listKeys = new List<AttackKey>();
            queueAttacks = new Queue<Keys>();

            //Import the Attack Patterns
            patternReader = new ImportAttackPatterns(enemy.PatternFileName);

            for (int i = 0; i < patternReader.AttackPattern.Count; i++)
            {
                queueAttacks.Enqueue(patternReader.AttackPattern[i]);
            }

            //Hitbox for blocking enemy attacks- it is actually just a rectangle
            hitbox = new Rectangle(100, 350, 100, 100);
            this.hitboxTexture = hitboxTexture;

            //Rectangle for drawing
            healthBoxTexture = healthBox;

            //Graphical stuff for the battle
            this.font = font;
            this.UpArrow = UpArrow;
            this.DownArrow = DownArrow;
            this.LeftArrow = LeftArrow;
            this.RightArrow = RightArrow;

            Victory = false;
            GameOver = false;
            RanAway = false;
        }

        //Methods
        public void Update(GameTime gameTime)
        {
            //Keybaord state
            pbState = kbState;
            kbState = Keyboard.GetState();

            //Update logic based on current game state
            switch (battleState)
            {
                case BattleState.Idle:
                    //Waits for the player to pick fight or runaway
                    //Player picks fight, change state
                    timerOriginal++;
                    if (timerOriginal>=10)
                    {
                        //Update the arrow position to decide which choice the user in highlighting
                        if (Helpers.SingleKeyPress(Keys.Up, pbState, kbState))
                        {
                            //If no choice has been selected yet or the top choice is selcted 
                            if (arrowPosition == 1)
                            {
                                arrowPosition = 2;
                            }
                            //Otherwise just move the position up 1
                            else
                            {
                                arrowPosition--;
                            }
                        }
                        else if (Helpers.SingleKeyPress(Keys.Down, pbState, kbState))
                        {
                            //If the bottom choice is selcted reset the position to the top choice.
                            if (arrowPosition == 2)
                            {
                                arrowPosition = 1;
                            }
                            //Otherwise just move the position down 1
                            else
                            {
                                arrowPosition++;
                            }
                        }

                        if (kbState.IsKeyDown(Keys.Enter) && pbState.IsKeyUp(Keys.Enter) && arrowPosition == 1)
                        {
                            battleState = BattleState.Fight;
                            timerOriginal = 0;
                            failedRun = false;
                        }
                        else if (kbState.IsKeyDown(Keys.Enter) && arrowPosition == 2)
                        {
                            //Check to see if the player successfully ran away
                            bool success = enemy.RunAway(chance, rng);
                            if (success && player.Stamina > 20)
                            {
                                battleState = BattleState.RanAway;
                                success = true;
                                timerOriginal = timer;
                            }
                            else
                            {
                                if (player.Stamina > 20)
                                {
                                    player.Stamina -= 10;
                                }
                                else
                                {
                                    runText = "Not enough stamina to run away!";
                                }

                                failedRun = true;
                            }

                            timerOriginal = 0;
                        }
                    }
                    
                    break;

                case BattleState.Fight:

                    //
                    //Processes attacks and damage
                    //Timer keeps track of elapsed battle time. Every attack tick, the next attack in the enemy's pattern will be
                    //created. The attack pattern will loop by default.
                    //


                    //Checks the key at the front of the list. Is it intersecting the hitbox?

                    if (listKeys.Count != 0 && listKeys[0] != null)
                    {
                        AttackKey firstAttack = listKeys[0];

                        if (firstAttack.Position.Intersects(hitbox))
                        {
                            //If it is intersecting the hitbox, we check if the player has pressed the appropriate key
                            if (Helpers.SingleKeyPress(firstAttack.KeyType, pbState, kbState))
                            {
                                //Get the Pressed Keys and save as an array of keys 
                                Keys[] keys = kbState.GetPressedKeys();

                                //Find which key should be pressed
                             
                                //If the player has pressed the correct key, then enemy stamina is lowered otherwise player stamina is lowered.
                                if (listKeys[0].KeyType == keys[0])
                                {
                                    enemy.Stamina -= 10;
                                }
                                else
                                {
                                    player.Stamina -= 10;
                                }

                                //Either way remove the key
                                listKeys.RemoveAt(0);

                            }
                        }
                    }

                    //
                    //Generate new attacks
                    //

                    timer += 1;

                    if (timer % attackTick == 0)
                    {
                        //Add a newly-created key to the list

                        if (queueAttacks.Peek() != Keys.None)
                        {
                            listKeys.Add(CreateKey(queueAttacks.Peek()));
                        }

                        //Add first entry to the end of the queue, remove it from the start.
                        //This behaviour is essentially looping an attack pattern.
                        queueAttacks.Enqueue(queueAttacks.Dequeue());
                    }


                    //
                    //Update the keys
                    //

                    //Remove a key if it is passed the hitbox- and damages the player!
                    if(listKeys.Count > 0 && (listKeys[0].Position.X + listKeys[0].Position.X < hitbox.X))
                    {
                        listKeys.RemoveAt(0);
                        player.Stamina -= 10;
                    }

                    //Calls update on each key.
                    foreach (AttackKey key in listKeys)
                    {
                        if (key != null) { key.Update(gameTime); }
                    }


                    //Then checks Win/Loss conditions
                    if (player.Stamina <= 0)
                    {
                        battleState = BattleState.Death;
                    }
                    else if(enemy.Stamina <=0)
                    {
                        battleState = BattleState.Victory;
                        timerOriginal = timer;
                    }
                    break;

                case BattleState.Death:
                    //What happens when the player stamina reaches 0
                    if (!GameOver)
                    {
                        GameOver = true;
                    }
                    break;

                case BattleState.Victory:
                    //What happens when the enemy stamina reaches  0
                    //Eventually, this should take some sort of transition time so the player can get  ready to go back into the game world.
                    //Without it it's all a little disorienting.
                    //int temp = timer - timerOriginal;
                    timer++;
                    if (!Victory && (timer - timerOriginal) >= 200)
                    {
                        Victory = true;
                        player.X = player.PrevPos.X;
                        player.Y = player.PrevPos.Y;
                    }
                    break;
                case BattleState.RanAway:
                    //If the player chooses to run away
                    timer++;
                    if (!RanAway && (timer - timerOriginal) >= 200)
                    {
                        RanAway = true;
                        player.X = player.PrevPos.X;
                        player.Y = player.PrevPos.Y;
                        enemy.X = enemy.PrevPos.X;
                        enemy.Y = enemy.PrevPos.Y;
                        //enemy.Active = false;
                        enemy.Transparent = true;
                        enemy.Timer = 0;
                        enemy.InBattle = false; 
                        enemy.Top = true; 
                        enemy.Right = true;
                        enemy.Once = true;
                        
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {

            //Some objects get drawn regardless of state, mostly GUI stuff.
            //Draws the hitbox.
            sb.Draw(hitboxTexture, hitbox, null, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 1.0f);

            //Draws the screen differently based on current state.
            switch (battleState)
            {

                case BattleState.Idle:
                    //Draws the health bars for the player and enemy
                    //enemy
                    sb.Draw(healthBoxTexture, new Vector2((float)595, (float)103), new Rectangle(600, 90, 210, 50), Color.Black);
                    sb.Draw(healthBoxTexture, new Vector2((float)600, (float)105), new Rectangle(600, 90, 200, 45), Color.Red);
                    sb.Draw(healthBoxTexture, new Vector2((float)600, (float)105), new Rectangle(590, 90, enemy.Stamina * 2, 45), Color.Green);
                    //player
                    sb.Draw(healthBoxTexture, new Vector2((float)41, (float)103), new Rectangle(40, 90, 205, 50), Color.Black);
                    sb.Draw(healthBoxTexture, new Vector2((float)40, (float)105), new Rectangle(40, 90, 200, 45), Color.Red);
                    sb.Draw(healthBoxTexture, new Vector2((float)40, (float)105), new Rectangle(40, 90, player.Stamina * 2, 45), Color.Green);

                    //Simply draws the options to fight (or not?) to the player
                    if (arrowPosition == 1)
                    {
                        sb.DrawString(font, "Fight", new Vector2(600, 250), Color.Red);
                    }
                    else
                    {
                        sb.DrawString(font, "Fight", new Vector2(600, 250), Color.Black);
                    }
                    if (arrowPosition == 2)
                    {
                        sb.DrawString(font, "Run Away", new Vector2(600, 280), Color.Red);
                    }
                    else
                    {
                        sb.DrawString(font, "Run Away", new Vector2(600, 280), Color.Black);
                    }

                    if (failedRun)
                    {
                        sb.DrawString(font, runText, new Vector2(400, 175), Color.Red);
                    }

                    break;

                case BattleState.Fight:
                    //Draws the health bars for the player and enemy
                    //enemy
                    sb.Draw(healthBoxTexture, new Vector2((float)595, (float)103), new Rectangle(600, 90, 210, 50), Color.Black);
                    sb.Draw(healthBoxTexture, new Vector2((float)600, (float)105), new Rectangle(600, 90, 200, 45), Color.Red);
                    sb.Draw(healthBoxTexture, new Vector2((float)600, (float)105), new Rectangle(590, 90, enemy.Stamina * 2, 45), Color.Green);
                    //player
                    sb.Draw(healthBoxTexture, new Vector2((float)41, (float)103), new Rectangle(40, 90, 205, 50), Color.Black);
                    sb.Draw(healthBoxTexture, new Vector2((float)40, (float)105), new Rectangle(40, 90, 200, 45), Color.Red);
                    sb.Draw(healthBoxTexture, new Vector2((float)40, (float)105), new Rectangle(40, 90, player.Stamina * 2, 45), Color.Green);



                    //Draws the attacks and any effects needed
                    foreach (AttackKey key in listKeys)
                    {
                        key.Draw(sb);
                    }
                    break;

                case BattleState.Death:
                    //Transition to game over
                    break;
                case BattleState.Victory:
                    //Show victory message and transition back to level
                    sb.DrawString(font, "Victory!", new Vector2(500, 100), Color.Red);
                    break;
                case BattleState.RanAway:
                    sb.DrawString(font, "Successfully Ran Away!", new Vector2(500, 100), Color.Red);
                    break;

            }

            //Draws player and enemy
            player.Draw(sb);
            enemy.Draw(sb, 1);

            //DEBUG: Draw battle info
            //sb.DrawString(font, battleState.ToString(), new Vector2(50, 100), Color.Beige);
            //sb.DrawString(font, "Player Stamina: " + player.Stamina, new Vector2(50, 150), Color.Beige);
            //sb.DrawString(font, "Enemy Stamina: " + enemy.Stamina, new Vector2(50, 200), Color.Beige);
            //sb.DrawString(font, "Elapsed Frames: " + timer, new Vector2(50, 250), Color.Beige);
        }

        //Creates a key object
        protected AttackKey CreateKey(Keys keyType)
        {
            AttackKey keyToReturn = null;

            //Creates the appropriate type of key based on the integer supplied
            if (keyType != Keys.None)
            {
                switch (keyType)
                {
                    case Keys.Up:
                        keyToReturn = new AttackKey(
                            UpArrow,
                            1200,
                            375,
                            keyType,
                            keySpeed);
                        break;
                    case Keys.Down:
                        keyToReturn = new AttackKey(
                            DownArrow,
                            1200,
                            375,
                            keyType,
                            keySpeed);
                        break;
                    case Keys.Left:
                        keyToReturn = new AttackKey(
                            LeftArrow,
                            1200,
                            375,
                            keyType,
                            keySpeed);
                        break;
                    case Keys.Right:
                        keyToReturn = new AttackKey(
                            RightArrow,
                            1200,
                            375,
                            keyType,
                            keySpeed);
                        break;
                    default:
                        break;
                }
                /*keyToReturn = new AttackKey(
                    keyTexture,
                    new Rectangle(1200, 400, keyTexture.Width, keyTexture.Height ),
                    keyType,
                    keySpeed);*/
            }

            return keyToReturn;
        }
    }
}
