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

    class Boss : Enemy
    {
        //Fields
        private AttackPattern pattern;
        private Texture2D idle;
        private Texture2D bowing;
        private Texture2D inBow;


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
        public Boss(Texture2D texture, Texture2D walkTexture, Texture2D battleTexture, int xPositon, int yPosition, int width, int height, Random rng, String patterneFileName) 
            : base(texture, walkTexture, battleTexture, xPositon, yPosition, width, height, rng, patterneFileName)
        {
            this.idle = texture;
            this.bowing = walkTexture;
            this.inBow = battleTexture;

            pattern = AttackPattern.Pattern1;

            this.battleTexture = battleTexture;

            // More Animation Variables that Exist to be changed later
            fps = 10.0;                     // Will cycle through 10 walk frames per second
            timePerFrame = 1.0 / fps;       // Time per frame = amount of time in a single walk image
            
        }

        public override void Update(GameTime gameTime)
        {
            //if (InBattle)
            //{
            //    //Handle Animation Timing
            //
            //    timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            //
            //    // If enough time has passed:
            //    if (timeCounter >= timePerFrame)
            //    {
            //        frame += 1;                     // Adjust the frame to the next image
            //
            //        if (frame > frameCount)     // Check the bounds - have we reached the end of walk cycle?
            //            frame = 1;                  // Back to 1 (since 0 is the "standing" frame)
            //
            //        timeCounter -= timePerFrame;    // Remove the time we "used" - don't reset to 0
            //                                        // This keeps the time passed 
            //    }
            //}

        }

        //public override void Draw(SpriteBatch sb)
        //{
        //    if (InBattle)
        //    {
        //        sb.Draw(texture, position, new Rectangle(rectOffsetX, rectOffsetY, rectWidth, rectHeight), Color.White);
        //    }
        //    else
        //    {
        //        base.Draw(sb);
        //    }
        //}
    }
}
