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
            Death
        }

    class Battle
    {
        //Fields
        protected int timer;
        protected int attackTick;
        protected int keySpeed;

        //References to player and enemy in battle
        protected Player player;
        protected Enemy enemy;

        //Resources
        protected SpriteFont font;
        protected Texture2D keyTexture;
        protected Texture2D hitboxTexture;
        
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

        //Constructor
        //The battle class will need a reference to an enemy and the player; it may also need to know other things, such as
        //the previous locations of the player and the enemies that were on the level.
        public Battle(KeyboardState kbState, KeyboardState pbState, SpriteFont font, Texture2D keyTexture, Texture2D hitboxTexture, Player player, Enemy enemy)
        {
            //The stars of the show...
            this.player = player;
            this.enemy = enemy;


            //attackTick is the number of frames before a new enemy attack will be created.
            //Although here it is a constant, it can be changed with different enemies.
            timer = 0;
            attackTick = 25;

            //Also hardcoded for now, eventually given by enemy?
            keySpeed = 5;

            //Positions to draw player and enemy
            player.PrevPos = player.Position;

            player.Position = new Rectangle(50, 200, 50, 50);
            enemy.Position = new Rectangle(600, 200, 50, 50);

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

            //DEBUG: HARD-CODED ATTACK LIST
            /*queueAttacks.Enqueue(Keys.Up);
            queueAttacks.Enqueue(Keys.Up);
            queueAttacks.Enqueue(Keys.None);
            queueAttacks.Enqueue(Keys.None);
            queueAttacks.Enqueue(Keys.Down);
            queueAttacks.Enqueue(Keys.Down);
            queueAttacks.Enqueue(Keys.None);
            queueAttacks.Enqueue(Keys.None);
            queueAttacks.Enqueue(Keys.Left);
            queueAttacks.Enqueue(Keys.Left);
            queueAttacks.Enqueue(Keys.None);
            queueAttacks.Enqueue(Keys.None);
            queueAttacks.Enqueue(Keys.Right);
            queueAttacks.Enqueue(Keys.Right);
            queueAttacks.Enqueue(Keys.None);
            queueAttacks.Enqueue(Keys.None);*/


            //Hitbox for blocking enemy attacks- it is actually just a rectangle
            hitbox = new Rectangle(100, 350, 100, 100);
            this.hitboxTexture = hitboxTexture;

            //Graphical stuff for the battle
            this.font = font;
            this.keyTexture = keyTexture;

            Victory = false;
            GameOver = false;
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
                    if (kbState.IsKeyDown(Keys.F))
                    {
                        battleState = BattleState.Fight;
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
                                //If the player has pressed the key, then enemy stamina is lowered and the key is removed.
                                listKeys.RemoveAt(0);
                                enemy.Stamina -= 10;
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
                    if (!Victory)
                    {
                        Victory = true;
                        player.Position = player.PrevPos;
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
                    //Simply draws the options to fight (or not?) to the player
                    break;

                case BattleState.Fight:
                    //Draws the attacks and any effects needed
                    foreach(AttackKey key in listKeys)
                    {
                        key.Draw(sb);
                    }
                    break;

                case BattleState.Death:
                    //Transition to game over
                    break;
                case BattleState.Victory:
                    //Show victory message and transition back to level
                    break;

            }

            //Draws player and enemy
            player.Draw(sb);
            enemy.Draw(sb);

            //DEBUG: Draw battle info
            sb.DrawString(font, battleState.ToString(), new Vector2(50, 100), Color.Beige);
            sb.DrawString(font, "Player Stamina: " + player.Stamina, new Vector2(50, 150), Color.Beige);
            sb.DrawString(font, "Enemy Stamina: " + enemy.Stamina, new Vector2(50, 200), Color.Beige);
            sb.DrawString(font, "Elapsed Frames: " + timer, new Vector2(50, 250), Color.Beige);
        }

        //Creates a key object
        protected AttackKey CreateKey(Keys keyType)
        {
            AttackKey keyToReturn = null;

            //Creates the appropriate type of key based on the integer supplied
            if (keyType != Keys.None)
            {
                keyToReturn = new AttackKey(
                    keyTexture,
                    new Rectangle(1200, 400, keyTexture.Width, keyTexture.Height ),
                    keyType,
                    keySpeed);
            }

            return keyToReturn;
        }
    }
}
