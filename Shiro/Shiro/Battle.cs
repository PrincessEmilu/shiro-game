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

        //Updates player and enemy stamina, but also used for tracking state.
        protected int playerStamina;
        protected int enemyStamina;

        //List of keys
        protected List<AttackKey> listKeys;

        //Location on battlescreen to draw the enemy and the player
        protected Point playerPositon;
        protected Point enemyPosition;

        //Battle starts out idle
        protected BattleState battleState = BattleState.Idle;

        //Constructor
        //The battle class will need a reference to an enemy and the player; it may also need to know other things, such as
        //the previous locations of the player and the enemies that were on the level.
        public Battle(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;

            playerStamina = player.Stamina;
            enemyStamina = enemy.Stamina;

            listKeys = new List<AttackKey>();
        }

        //Methods
        public void Update()
        {
            //Update logic based on current game state
            switch (battleState)
            {
                case BattleState.Idle:
                    //Waits for the player to pick fight or runaway
                    break;
                case BattleState.Fight:
                    //Processes attacks and damage

                    //stuff
                    //goes
                    //here

                    //Then checks Win/Loss conditions
                    if (playerStamina <= 0)
                    {
                        battleState = BattleState.Death;
                    }
                    else if(enemyStamina <=0)
                    {
                        battleState = BattleState.Victory;
                    }
                    break;

                case BattleState.Death:
                    //What happens when the player stamina reaches 0
                    break;
                case BattleState.Victory:
                    //What happens when the enemy stamina reaches  0
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            //Some objects get drawn regardless of state, mostly GUI stuff.l

            //Draws the screen differently based on current state.
            switch (battleState)
            {
                case BattleState.Idle:
                    //Simply draws the options to fight (or not?) to the player
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
        }

        //Creates a key object
        protected void CreateKey()
        {

        }
    }
}
