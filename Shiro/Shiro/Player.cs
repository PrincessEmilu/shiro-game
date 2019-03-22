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
    class Player : GameObject
    {
        //Fields        
        private int windowHeight;
        private int windowWidth;

        

        //Property for the amount of stamina and previous position  
        public int Stamina { get; set; }

        public Rectangle PrevPos { get; set; }        

        public void Center()
        {
            position.X = windowWidth / 2;
            position.Y = windowHeight / 2;
        }

        public Player(Texture2D texture, Rectangle position, int width, int height) : base(texture, position)
        {            
            Stamina = 100;
            windowWidth = width;
            windowHeight = height;
            PrevPos = position;            
        }

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {
            //Moves the player based on key presses
            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Up))
            {
                position.Y -= 5;                
            }
            if (kbState.IsKeyDown(Keys.Down))
            {
                position.Y += 5;
            }
            if (kbState.IsKeyDown(Keys.Left))
            {
                position.X -= 5;
            }
            if (kbState.IsKeyDown(Keys.Right))
            {
                position.X += 5;
            }


            //Prevents player from going off the screen from the bottom or right
            if(position.Y >= 1450)
            {
                position.Y = 1449;
            }
            if (position.X >= 1450)
            {
                position.X = 1449;
            }

            //Prevents the player from going off the screen from the top or left
            if (position.Y <= 0)
            {
                position.Y = 1;
            }
            if (position.X <= 0)
            {
                position.X = 1;
            }           
        }

        public override void Draw(SpriteBatch sb)
        {        
            sb.Draw(texture, position, Color.White);
        }

        

    }
}
