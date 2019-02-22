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
        protected Battle(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;

            //will not compile player and enemy are implemented
            playerStamina = player.Stamina;
            enemyStamina = enemy.Stamina;

            listKeys = new List<AttackKey>();
        }

        //Methods
        protected void Update()
        {

        }

        protected void Draw(SpriteBatch sb)
        {

        }

        //Creates a key object
        protected void CreateKey()
        {

        }
    }
}
