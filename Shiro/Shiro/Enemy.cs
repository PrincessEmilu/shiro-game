using System;
using System.Threading;
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
        int endPoint;
        int startPoint;
        bool top;



        public Enemy(Texture2D texture, Rectangle position, int width, int height, Random rng) : base(texture, position)
        {
            stamina = 100;
            windowWidth = width;
            windowHeight = height;
            prevPos = position;
            this.rng = rng;
            endPoint = position.Y + 50;
            startPoint = position.Y;
            top = true;
            
        }

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {
            // ---- RANDOM CODE TO BE IMPLEMENTED ------
            //int rand = 1;
            //if (rand == 1)
            //{    

            //Up and down movement, tied to set points based on enemy's starting point, made in constructor
            if (top)
            {
                if (position.Y >= startPoint)
                {
                    position.Y += 1;
                    
                    if(position.Y == endPoint)
                    {
                        top = false;
                    }
                }               
            }
            else
            {
                if (position.Y <= endPoint)
                {
                    position.Y -= 1;
                    if(position.Y == startPoint)
                    {
                        top = true;
                    }
                    
                }
            }          
            
            //}
            /*
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
            }*/

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
