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
    class Enemy : GameObject
    {
        //Fields        
        private int stamina;
        private int windowHeight;
        private int windowWidth;
        private Rectangle prevPos;
        private Random rng;


        public Enemy(Texture2D texture, Rectangle position, int width, int height, Random rng) : base(texture, position)
        {
            stamina = 100;
            windowWidth = width;
            windowHeight = height;
            prevPos = position;
            this.rng = rng;
        }

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {
            int rand = rng.Next(1, 5);
            if (rand == 1)
            {    
                position.Y += 5;
                position.X += 5;
                position.Y -= 5;
                position.X -= 5;

                
            }
            if (rand == 2)
            {
                position.Y += 5;
            }
            if (rand == 3)
            {
                position.X -= 5;
            }
            if (rand == 4)
            {
                position.X += 5;
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

    }
}
