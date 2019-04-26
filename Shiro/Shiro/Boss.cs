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
        private Texture2D idle;
        private Texture2D bowing;
        private Texture2D inBow;
        private AnimationState state;
        private int stamina;
        private int frameTimer;
        private int goalFrame;
        private string patternFileName;

        private int timer;

        private int frame;              // The current animation frame

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

                    }

                    break;
                default:
                    break;
            }

           
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

    }
}
