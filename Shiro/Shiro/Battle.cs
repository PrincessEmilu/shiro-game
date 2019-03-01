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
        //References to player and enemy in battle
        protected Player player;
        protected Enemy enemy;

        //Resources
        protected SpriteFont font;
        protected KeyboardState kbState;
        protected KeyboardState pbState;

        //List of keys
        protected List<AttackKey> listKeys;

        //Location on battlescreen to draw the enemy and the player
        protected Point playerPositon;
        protected Point enemyPosition;

        //Battle starts out idle
        protected BattleState battleState = BattleState.Idle;

        //Properties
        public bool Victory { get; private set; }
        public bool GameOver { get; private set; }

        //Constructor
        //The battle class will need a reference to an enemy and the player; it may also need to know other things, such as
        //the previous locations of the player and the enemies that were on the level.
        public Battle(KeyboardState kbState, KeyboardState pbState, SpriteFont font, Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;

            listKeys = new List<AttackKey>();

            this.font = font;

            Victory = false;
            GameOver = false;
        }

        //Methods
        public void Update()
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
                    //Processes attacks and damage

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
        }

        //Creates a key object
        protected void CreateKey()
        {

        }
    }
}
