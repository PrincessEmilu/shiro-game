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

    class Boss //: Enemy
    {
        //Fields
        private AttackPattern pattern;
        private Texture2D idle;
        private Texture2D bowing;
        private Texture2D inBow;
        private AnimationState state;
        private Rectangle position;

        private int timer;

        //Fields Used For the SpriteSheet
        int frame;              // The current animation frame
        double timeCounter;     // The amount of time that has passed
        double fps;             // The speed of the animation
        double timePerFrame;    // The amount of time (in fractional seconds) per frame
        
        // Constants for "source" rectangle in Sprite Sheet
        //These numbers are placeholders and need to be changed eventually
        
        const int frameCount = 0;       // The number of frames in the animation
        const int rectOffsetX = 0;     // How far right in the image are the frames?
        const int rectOffsetY = 0;   // How far down in the image are the frames?
        const int rectHeight = 0;     // The height of a single frame
        const int rectWidth = 0;      // The width of a single frame


        //Properties
        public AttackPattern Pattern
        {
            get { return pattern; }
            set { pattern = value; }
        }

        //Constructor
        public Boss(Texture2D idle, Texture2D special, Texture2D special2, int xPositon, int yPosition, int width, int height,  String patterneFileName)
            //: base(texture, walkTexture, battleTexture, xPositon, yPosition, width, height, rng, patterneFileName)
        {
            this.idle = idle;
            this.bowing = special;
            this.inBow = special2;
            this.state = AnimationState.Idle;
            this.timer = 0;

            position = new Rectangle(xPositon, yPosition, width, height);

            pattern = AttackPattern.Pattern1;

            // More Animation Variables that Exist to be changed later
            //fps = 10.0;                     // Will cycle through 10 walk frames per second
            //timePerFrame = 1.0 / fps;       // Time per frame = amount of time in a single walk image

        }

        public  void Update(GameTime gameTime)
        {


            switch (state)
            {
                case AnimationState.Idle:
                    timer++;
                    if (timer >= 200)
                    {
                        state = AnimationState.DownBow;
                        timer = 0;
                    }
                    break;
                case AnimationState.Bowing:
                    timer++;
                    if (timer >= 200)
                    {
                        state = AnimationState.DownBow;
                        timer = 0;
                    }
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            //Increase the frame, which will animate the player.
            int frameWidth = 410;
            int frameHeight = 400;

            //Calculates x/y offset to draw based on current frame and the tiles per row
            int xDrawOffset = frame % 7 * (frameWidth + 10);//frame % 7 * frameWidth;
            int yDrawOffest = frame / 7 * (frameHeight + 10);



            //Actualy logic for drawing the sprite

            switch (state)
            {
                case AnimationState.Idle:
                    sb.Draw(
                    idle,                                                //Texture to draw
                    position,        //Rectangle to draw to
                    new Rectangle(xDrawOffset, yDrawOffest, 430, 420),      //Source rectangle to draw from file
                    Color.White,                                  //Blend color
                    0f,                                                     //Rotation
                    new Vector2(0, 0),                                       //Origin
                    SpriteEffects.FlipHorizontally,                         //Sprite Effects
                    0f                                                      //Layer to draw on
                    );
                    break;
                    break;
                case AnimationState.DownBow:
                    sb.Draw(
                    bowing,                                                //Texture to draw
                    position,        //Rectangle to draw to
                    new Rectangle(xDrawOffset, yDrawOffest, 430, 420),      //Source rectangle to draw from file
                    Color.White,                                  //Blend color
                    0f,                                                     //Rotation
                    new Vector2(0, 0),                                       //Origin
                    SpriteEffects.FlipHorizontally,                         //Sprite Effects
                    0f                                                      //Layer to draw on
                    );

                    if (frame == 60)
                    {
                        state = AnimationState.Bowing;
                    }
                    break;
                case AnimationState.Bowing:
                    sb.Draw(
                    inBow,                                                //Texture to draw
                    position,        //Rectangle to draw to
                    new Rectangle(xDrawOffset, yDrawOffest, 430, 420),      //Source rectangle to draw from file
                    Color.White,                                  //Blend color
                    0f,                                                     //Rotation
                    new Vector2(0, 0),                                       //Origin
                    SpriteEffects.FlipHorizontally,                         //Sprite Effects
                    0f                                                      //Layer to draw on
                    );
                    break;
                case AnimationState.UpBow:
                    sb.Draw(
                    bowing,                                                //Texture to draw
                    position,        //Rectangle to draw to
                    new Rectangle(xDrawOffset, yDrawOffest, 430, 420),      //Source rectangle to draw from file
                    Color.White,                                  //Blend color
                    0f,                                                     //Rotation
                    new Vector2(0, 0),                                       //Origin
                    SpriteEffects.FlipHorizontally,                         //Sprite Effects
                    0f                                                      //Layer to draw on
                    );

                    if (frame == 0)
                    {
                        state = AnimationState.Idle;
                    }
                    break;
                default:
                    break;
            }

            if (state != AnimationState.UpBow)
            {
                frame += 1;

                if (frame == 60) { frame = 0; }

            }
            else
            {
                frame -= 1;

                if (frame == 0)
                {
                    frame = 60;
                }
            }
        }
    }
}
