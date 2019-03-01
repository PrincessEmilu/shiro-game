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

        int endPointY;
        int startPointY;
        int endPointX;
        int startPointX;

        int enemyRng;
        bool top;
        bool right;



        public Enemy(Texture2D texture, Rectangle position, int width, int height, Random rng) : base(texture, position)
        {
            stamina = 100;
            windowWidth = width;
            windowHeight = height;
            prevPos = position;
            this.rng = rng;

            endPointY = position.Y + 100;
            startPointY = position.Y;
            endPointX = position.X + 100;
            startPointX = position.X;

            enemyRng = rng.Next(1, 5);
            
            top = true;
            right = true;
            
            
        }

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {
            // ---- RANDOM CODE TO BE IMPLEMENTED ------

            if (enemyRng == 1)
            {
                //Up and down movement, tied to set points based on enemy's starting point, made in constructor
                if (top)
                {
                    if (position.Y >= startPointY)
                    {
                        position.Y += 1;

                        if (position.Y == endPointY)
                        {
                            top = false;
                        }
                    }
                }
                else
                {
                    if (position.Y <= endPointY)
                    {
                        position.Y -= 1;
                        if (position.Y == startPointY)
                        {
                            top = true;
                        }

                    }
                }
            }
            if (enemyRng == 2)
            {
                //Left and Right movement, tied to set points based on enemy's starting point, made in constructor
                if (right)
                {
                    if (position.X >= startPointX)
                    {
                        position.X += 1;

                        if (position.X == endPointX)
                        {
                            right = false;
                        }
                    }
                }
                else
                {
                    if (position.X <= endPointX)
                    {
                        position.X -= 1;
                        if (position.X == startPointX)
                        {
                            right = true;
                        }

                    }
                }
            }
            if(enemyRng == 3) //moving in a counter clockwise square
            {
                if (top && right)
                {
                    if (position.Y >= startPointY)
                    {
                        position.Y += 1;

                        if (position.Y >= endPointY) //reached bottom
                        {
                            if (position.X >= startPointX)
                            {
                                position.X += 1;
                                position.Y = endPointY;

                                if (position.X == endPointX)
                                {
                                    right = false;
                                    top = false;
                                }
                            }
                            
                        }
                    }
                }
                else
                {
                   if (position.Y <= endPointY)
                   {
                       position.Y -= 1;
                       if (position.Y <= startPointY)
                       {
                            position.Y = startPointY;

                            if (position.X <= endPointX)
                            {
                                position.X -= 1;
                                
                                if (position.X == startPointX)
                                {
                                    right = true;
                                    top = true;
                                }
                            }
                       }

                   }
                }
            }
            if (enemyRng == 4) //moving in a clockwise square
            {
                if (top && right)
                {
                    if (position.X >= startPointX)
                    {
                        position.X += 1;

                        if (position.X >= endPointX) //reached max x
                        {
                            if (position.Y >= startPointY)
                            {
                                position.Y += 1;
                                position.X = endPointX;

                                if (position.Y == endPointY)
                                {
                                    right = false;
                                    top = false;
                                }
                            }

                        }
                    }
                }
                else
                {
                    if (position.X <= endPointX)
                    {
                        position.X -= 1;
                        if (position.X <= startPointX)
                        {
                            position.X = startPointX;

                            if (position.Y <= endPointY)
                            {
                                position.Y -= 1;

                                if (position.Y == startPointY)
                                {
                                    right = true;
                                    top = true;
                                }
                            }
                        }

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
