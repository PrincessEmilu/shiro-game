﻿using System;
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

    //Enemy states
    enum EnemyState
    {
        FaceRight,
        FaceLeft,
        WalkRight,
        WalkLeft
    }

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
        protected bool once;

        protected int timer;

        protected EnemyState currentState;

        private int frame;
        private Texture2D walkTexture;

        protected bool transparent;


        //Properties
        public bool Active { get; set; }
        public bool InBattle { get; set; }
        public string PatternFileName
        {
            get { return patternFileName; }
        }
        public bool Transparent
        {
            get { return transparent; }
            set
            {
                transparent = value;
            }
        }

        public bool Top
        {
            get { return top; }
            set
            {
                top = value;
            }
        }

        public bool Right
        {
            get { return right; }
            set
            {
                right = value;
            }
        }

        public bool Once
        {
            get { return once; }
            set
            {
                once = value;
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

        public int Timer
        {
            get { return timer; }

            set
            {
                timer = value;
            }
        }

        public Enemy(Texture2D texture, Texture2D walkTexture, int xPosition, int yPosition, int width, int height, Random rng, string patternFileName) : base(texture, xPosition, yPosition) //random movement
        {
            //this constructor is for random movement type at a set distance of 100
            frame = 0;
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
            once = true;

            timer = 0;

            this.walkTexture = walkTexture;
            currentState = EnemyState.FaceRight;

            //Set collision box width to be the target box width/height for the object
            position.Width = 100;
            position.Height = 115;
        }

        public Enemy(Texture2D texture, Texture2D walkTexture, int xPosition, int yPosition, int width, int height, int enemyRng, int distance, String patternFileName) : base(texture, xPosition, yPosition)
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
            once = true;

            timer = 0;

            this.walkTexture = walkTexture;
            currentState = EnemyState.WalkRight;

            //Set collision box width to be the target box width/height for the object
            position.Width = 100;
            position.Height = 115;

        }

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {
            //Turns off if stamins = 0
            if (Stamina <= 0)
            {
                Active = false;
            }

            if(once)
            {
                startPointX = position.X;
                startPointY = position.Y;
                once = false;
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
                            currentState = EnemyState.WalkRight;
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
                            currentState = EnemyState.WalkLeft;
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
                                    currentState = EnemyState.WalkLeft;
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
                            currentState = EnemyState.WalkRight;
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
                            currentState = EnemyState.WalkLeft;
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
                    currentState = EnemyState.FaceLeft;
                    return true; //returns true to enter battle state
                }
            }
            else
            {
                return false;
            }

            return false;
        }


        public override void Draw(SpriteBatch sb, float opacity)
        {

            //Increase the frame, which will animate the player.
            int frameWidth = 300;
            int frameHeight = 350;

            //Calculates x/y offset to draw based on current frame and the tiles per row
            int xDrawOffset = frame % 7 * (frameWidth + 10);//frame % 7 * frameWidth;
            int yDrawOffest = frame / 7 * (frameHeight + 10);

            frame += 1;

            if (frame == 60) { frame = 0; }

            //Actualy logic for drawing the sprite

            switch (currentState)
            {
                case EnemyState.FaceLeft:
                //public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
                sb.Draw(
                    texture,                                                //Texture to draw
                    new Rectangle(position.X, position.Y, 100, 115),        //Rectangle to draw to
                    new Rectangle(xDrawOffset, yDrawOffest, 320, 370),      //Source rectangle to draw from file
                    Color.White * opacity,                                  //Blend color
                    0f,                                                     //Rotation
                    new Vector2(0, 0),                                       //Origin
                    SpriteEffects.FlipHorizontally,                         //Sprite Effects
                    0f                                                      //Layer to draw on
                    );
                    break;

                case EnemyState.FaceRight:
                    //public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
                    sb.Draw(
                        texture,                                                //Texture to draw
                        new Rectangle(position.X, position.Y, 100, 115),        //Rectangle to draw to
                        new Rectangle(xDrawOffset, yDrawOffest, 320, 370),      //Source rectangle to draw from file
                        Color.White * opacity                                   //Blend color
                        );
                    break;
                case EnemyState.WalkLeft:
                    //public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
                    sb.Draw(
                        walkTexture,                                                //Texture to draw
                        new Rectangle(position.X, position.Y, 100, 115),        //Rectangle to draw to
                        new Rectangle(xDrawOffset, yDrawOffest, 320, 370),      //Source rectangle to draw from file
                        Color.White * opacity,                                  //Blend color
                        0f,                                                     //Rotation
                        new Vector2(0, 0),                                       //Origin
                        SpriteEffects.FlipHorizontally,                         //Sprite Effects
                        0f                                                      //Layer to draw on
                        );
                    break;

                case EnemyState.WalkRight:
                    //public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
                    sb.Draw(
                        walkTexture,                                                //Texture to draw
                        new Rectangle(position.X, position.Y, 100, 115),        //Rectangle to draw to
                        new Rectangle(xDrawOffset, yDrawOffest, 320, 370),      //Source rectangle to draw from file
                        Color.White * opacity                                   //Blend color
                        );
                    break;
            }
        }
    }
}
