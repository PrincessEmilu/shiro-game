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
        private int stamina;
        private int windowHeight;
        private int windowWidth;
        private Rectangle prevPos;


        public Player(Texture2D texture, Rectangle position, int width, int height) : base(texture, position)
        {            
            stamina = 100;
            windowWidth = width;
            windowHeight = height;
            prevPos = position;
        }

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {
            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Up))
            {
                position.Y -= 1;
            }
            if (kbState.IsKeyDown(Keys.Down))
            {
                position.Y += 1;
            }
            if (kbState.IsKeyDown(Keys.Left))
            {
                position.X -= 1;
            }
            if (kbState.IsKeyDown(Keys.Right))
            {
                position.X += 1;
            }

            /* Wrap around the screen
            position.X += windowWidth;
            position.Y += windowHeight;
            position.X %= windowWidth;
            position.Y %= windowHeight;*/
        }

        //Property for the amount of stamina and previous position  
        public int Stamina
        {
            get { return stamina; }

            set
            {
                stamina = value;
            }
        }

        public Rectangle PrevPos
        {
            get { return prevPos; }
            set
            {
                prevPos = value;
            }
        }

        public void Center()
        {
            position.X = windowWidth / 2;
            position.Y = windowHeight / 2;
        }

    }
}
