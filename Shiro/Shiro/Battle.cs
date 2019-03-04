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
        protected KeyboardState kbState;
        protected KeyboardState pbState;

        //List of keys
        protected List<AttackKey> listKeys;
        protected Queue<int> queueAttacks;

        //Location on battlescreen to draw the enemy and the player
        protected Point playerPosition;
        protected Point enemyPosition;

        //Battle starts out idle
        protected BattleState battleState = BattleState.Idle;

        //Properties
        public bool Victory { get; private set; }
        public bool GameOver { get; private set; }

        //Constructor
        //The battle class will need a reference to an enemy and the player; it may also need to know other things, such as
        //the previous locations of the player and the enemies that were on the level.
        public Battle(KeyboardState kbState, KeyboardState pbState, SpriteFont font, Texture2D keyTexture, Player player, Enemy enemy)
        {
            //The starts of the show...
            this.player = player;
            this.enemy = enemy;


            //attackTick is the number of frames before a new enemy attack will be created.
            //Although here it is a constant, it can be changed with different enemies.
            timer = 0;
            attackTick = 100;

            //Also hardcoded for now, eventually given by enemy?
            keySpeed = 5;

            //Positions to draw player and enemy
            player.PrevPos = player.Position;

            player.Position = new Rectangle(50, 200, 50, 50);
            enemy.Position = new Rectangle(600, 200, 50, 50);

            //listKeys holds the key attack objects. queueAttacks hold the attack pattern from the enemy in battle.
            //For now, it is a hard-coded value.
            listKeys = new List<AttackKey>();
            queueAttacks = new Queue<int>();

            queueAttacks.Enqueue(1);
            queueAttacks.Enqueue(2);
            queueAttacks.Enqueue(3);
            queueAttacks.Enqueue(4);
            queueAttacks.Enqueue(0);
            queueAttacks.Enqueue(0);

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

                    timer += 1;

                    if (timer % attackTick == 0)
                    {
                        listKeys.Add(CreateKey(queueAttacks.Peek()));

                        //Add first entry to the end of the list, remove it from the start.
                        queueAttacks.Enqueue(queueAttacks.Dequeue());
                    }

                    //Update the keys
                    foreach(AttackKey key in listKeys)
                    {
                        if (key != null) { key.Update(gameTime); }
                    }

                    //DEBUG: DAMAGE PLAYER
                    if (kbState.IsKeyDown(Keys.F) && pbState.IsKeyUp(Keys.F))
                    {
                        player.Stamina -= 10;
                    }

                    //DEBUG: DAMAGE ENEMY
                    if (kbState.IsKeyDown(Keys.E) && pbState.IsKeyUp(Keys.E))
                    {
                        enemy.Stamina -= 10;
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

            //Draws the screen differently based on current state.
            switch (battleState)
            {
                case BattleState.Idle:
                    //Simply draws the options to fight (or not?) to the playe
                    break;

                case BattleState.Fight:
                    //Draws the attacks and any effects needed
                    foreach(AttackKey key in listKeys)
                    {
                        if (key != null) { key.Draw(sb); }
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
        protected AttackKey CreateKey(int keyValue)
        {
            AttackKey keyToReturn = null;

            //Creates the appropriate type of key based on the integer supplied
            if (keyValue != 0)
            {
                keyToReturn = new AttackKey(
                    keyTexture,
                    new Rectangle(800, 500, keyTexture.Width, keyTexture.Height ),
                    keyValue,
                    keySpeed);
            }

            return keyToReturn;
        }
    }
}
