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
        protected int stamina;
        protected int windowHeight;
        protected int windowWidth;
        protected Rectangle prevPos;
        protected Random rng;
        protected string patternFileName;

        protected int endPointY;
        protected int startPointY;
        protected int endPointX;
        protected int startPointX;

        protected int enemyRng;
        protected bool top;
        protected bool right;

        //Properties
        public bool Active { get; set; }
        public bool InBattle { get; set; }
        public string PatternFileName
        {
            get { return patternFileName; }
        }

        public Enemy(Texture2D texture, Rectangle position, int width, int height, Random rng, string patternFileName) : base(texture, position) //random movement
        {
            //this constructor is for random movement type at a set distance of 100

            stamina = 1000;
            windowWidth = width;
            windowHeight = height;
            prevPos = position;
            this.rng = rng;
            this.patternFileName = patternFileName;

            Active = true;
            InBattle = false;

            endPointY = position.Y + 100;
            startPointY = position.Y;
            endPointX = position.X + 100;
            startPointX = position.X;

            enemyRng = rng.Next(1, 5);
            
            top = true;
            right = true;
        }

        public Enemy(Texture2D texture, Rectangle position, int width, int height, int enemyRng, int distance, String patternFileName) : base(texture, position)
        {
            //this constructor is for a set movement type and distance, if you only want distance, you need to use rng.Next(1,5)

            stamina = 100;
            windowWidth = width;
            windowHeight = height;
            prevPos = position;
            this.patternFileName = patternFileName;

            Active = true;
            InBattle = false;
            

            endPointY = position.Y + distance;
            startPointY = position.Y;
            endPointX = position.X + distance;
            startPointX = position.X;

            this.enemyRng = enemyRng;

            top = true;
            right = true;
        }

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {
            //Turns off if stamins = 0
            if (Stamina <= 0)
            {
                Active = false;
            }

            //Only move around if not in battle
            if (!InBattle)
            {
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
                if (enemyRng == 3) //moving in a counter clockwise square
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
            }
            
        }

        //Check Collison
        public bool CheckCollision(GameObject check)
        {
            if (Active == true)
            {
                if (position.Intersects(check.Position)) //check if intersecting with the player
                {
                    InBattle = true;
                    return true; //returns true to enter battle state
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public override void Draw(SpriteBatch sb)
        {
            if (Active == true)
            {
                base.Draw(sb);
            }
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
