﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shiro
{
    enum AttackPattern
    {
        Pattern1,
        Pattern2
    }

    enum AnimationState
    {
        Idle,
        DownBow,
        Bowing,
        UpBow,
    }

    class Boss : GameObject
    {
        //Fields
        private AttackPattern pattern;
        private Texture2D idle;
        private Texture2D bowing;
        private Texture2D inBow;
        private AnimationState state;
        private Rectangle position;
        private int stamina;
        private int frameTimer;
        private int goalFrame;
        private string patternFileName;

        private int timer;

        ////Fields Used For the SpriteSheet
        int frame;              // The current animation frame
        //double timeCounter;     // The amount of time that has passed
        //double fps;             // The speed of the animation
        //double timePerFrame;    // The amount of time (in fractional seconds) per frame
        //
        //// Constants for "source" rectangle in Sprite Sheet
        ////These numbers are placeholders and need to be changed eventually
        //
        //const int frameCount = 60;       // The number of frames in the animation
        //const int rectOffsetX = 10;     // How far right in the image are the frames?
        //const int rectOffsetY = 10;   // How far down in the image are the frames?
        //const int rectHeight = 400;     // The height of a single frame
        //const int rectWidth = 410;      // The width of a single frame


        //Properties
        public AttackPattern Pattern
        {
            get { return pattern; }
            set { pattern = value; }
        }

        public bool Active { get; set; }

        public bool InBattle { get; set; }

        public int Stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }

        public string PatternFileName
        {
            get { return patternFileName; }
            set { patternFileName = value; }
        }

        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }

        //Constructor
        public Boss(Texture2D texture, Texture2D walkTexture, Texture2D battleTexture, int xPositon, int yPosition, int width, int height, Random rng, String patterneFileName)
            : base(texture, xPositon, yPosition)
        {
            this.idle = texture;
            this.bowing = walkTexture;
            this.inBow = battleTexture;
            this.state = AnimationState.Idle;
            this.timer = 0;
            this.stamina = 500;
            this.frame = 0;
            this.frameTimer = 0;
            this.patternFileName = patterneFileName;
            Active = true;
            InBattle = false;
            position = new Rectangle(xPositon, yPosition, width, height);

            pattern = AttackPattern.Pattern1;

            // More Animation Variables that Exist to be changed later
            //fps = 10.0;                     // Will cycle through 10 walk frames per second
            //timePerFrame = 1.0 / fps;       // Time per frame = amount of time in a single walk image

        }

        public override void Update(GameTime gameTime)
        {

            //Turns off if stamins = 0
            if (stamina <= 0)
            {
                Active = false;
            }

            switch (state)
            {
                case AnimationState.Idle:
                    timer++;
                    if (timer >= 200)
                    {
                        state = AnimationState.DownBow;
                        frame = 0;
                        timer = 0;
                    }
                    break;
                case AnimationState.Bowing:
                    timer++;
                    if (timer >= 200)
                    {
                        state = AnimationState.UpBow;
                        frame = 29;
                        timer = 0;
                    }
                    break;
                default:
                    break;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            if (!Active)
            {
                return;
            }

            //Increase the frame, which will animate the player.
            //Change Variable for this specific spritesheet
           int  frameWidth = 410;
           int frameHeight = 400;
           int xPadding = 10;
           int yPadding = 10;
 
           int xDrawOffset = frame % 7 * (frameWidth + xPadding);//frame % 7 * frameWidth;
           int yDrawOffest = frame % 7 * (frameHeight + yPadding);


            //Actualy logic for drawing the sprite

            switch (state)
            {
                case AnimationState.Idle:

                    goalFrame = 7;

                    sb.Draw(
                        idle,                                                //Texture to draw
                        position,        //Rectangle to draw to
                        new Rectangle(xDrawOffset, yDrawOffest, frameWidth, frameHeight + 3),      //Source rectangle to draw from file
                        Color.White,                                             //Blend color
                        0f,                                                     //Rotation
                        new Vector2(0, 0),                                       //Origin
                        SpriteEffects.FlipHorizontally,                         //Sprite Effects
                        0f                                                      //Layer to draw on
                        );

                    //Test
                    frameTimer++;

                    if (frameTimer >= goalFrame)
                    {
                        frame += 1;
                        frameTimer = 0;
                    }

                    if (frame == 60)
                    {
                        frame = 0;
                    }
                    break;

                case AnimationState.DownBow:

                    goalFrame = 7;

                    xDrawOffset = frame % 5 * (frameWidth + xPadding);//frame % 7 * frameWidth;
                    yDrawOffest = frame % 6 * (frameHeight + yPadding);

                    sb.Draw(
                        bowing,                                                //Texture to draw
                        position,        //Rectangle to draw to
                        new Rectangle(xDrawOffset, yDrawOffest, frameWidth, frameHeight),      //Source rectangle to draw from file
                        Color.White,                                  //Blend color
                        0f,                                                     //Rotation
                        new Vector2(0, 0),                                       //Origin
                        SpriteEffects.FlipHorizontally,                         //Sprite Effects
                        0f                                                      //Layer to draw on
                        );

                    //Test
                    frameTimer++;

                    if (frameTimer >= goalFrame)
                    {
                        frame += 1;
                        frameTimer = 0;
                    }

                    if (frame == 5)
                    {
                        frame = 0;
                        state = AnimationState.Bowing;
                    }

                    break;
                case AnimationState.Bowing:

                    goalFrame = 5;

                    sb.Draw(
                        inBow,                                                //Texture to draw
                        position,        //Rectangle to draw to
                        new Rectangle(xDrawOffset, yDrawOffest, frameWidth, frameHeight),      //Source rectangle to draw from file
                        Color.White,                                  //Blend color
                        0f,                                                     //Rotation
                        new Vector2(0, 0),                                       //Origin
                        SpriteEffects.FlipHorizontally,                         //Sprite Effects
                        0f                                                      //Layer to draw on
                        );

                    //Test
                    frameTimer++;

                    if (frameTimer >= goalFrame)
                    {
                        frame += 1;
                        frameTimer = 0;
                    }

                    if (frame == 60)
                    {
                        frame = 0;
                    }
                    break;

                case AnimationState.UpBow:

                    goalFrame = 7;


                    xDrawOffset = frame % 5 * (frameWidth + xPadding);//frame % 7 * frameWidth;
                    yDrawOffest = frame % 6 * (frameHeight + yPadding);

                    sb.Draw(
                        bowing,                                                //Texture to draw
                        position,        //Rectangle to draw to
                        new Rectangle(xDrawOffset, yDrawOffest, frameWidth, frameHeight),      //Source rectangle to draw from file
                        Color.White,                                  //Blend color
                        0f,                                                     //Rotation
                        new Vector2(0, 0),                                       //Origin
                        SpriteEffects.FlipHorizontally,                         //Sprite Effects
                        0f                                                      //Layer to draw on
                        );

                    //Test
                    frameTimer++;

                    if (frameTimer >= goalFrame)
                    {
                        frame -= 1;
                        frameTimer = 0;
                    }

                    if (frame == 25)
                    {
                        state = AnimationState.Idle;
                        //frame = 0;

                    }

                    break;
                default:
                    break;
            }

            //if (state != AnimationState.UpBow)
            //{
            //    frameTimer++;
            //
            //    if (frameTimer >= goalFrame)
            //    {
            //        frame += 1;
            //        frameTimer = 0;
            //    }
            //
            //    if (frame == 60 || (frame == 30 && state == AnimationState.DownBow))
            //    {
            //        if (state == AnimationState.DownBow)
            //        {
            //            state = AnimationState.Bowing;
            //            frame = 0;
            //        }
            //
            //        frame = 0;
            //    }
            //
            //}
            //else
            //{
            //    frameTimer++;
            //
            //    if (frameTimer >= goalFrame)
            //    {
            //        frame -= 1;
            //        frameTimer = 0;
            //    }
            //
            //    if (frame == 0)
            //    {
            //        state = AnimationState.Idle;
            //        frame = 60;
            //
            //    }
            //}

        }

       

        public bool CheckCollision(GameObject check)
        {
            if (Active == true)
            {
                if (position.Intersects(check.Position)) //check if intersecting with the player
                {
                    InBattle = true;
                    state = AnimationState.Idle;
                    return true; //returns true to enter battle state
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        //public override bool RunAway(int chance, Random rng)
        //{
        //    int random = rng.Next(1, 11);
        //    if (random <= chance)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
