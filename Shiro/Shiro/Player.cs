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
        private int windowHeight;
        private int windowWidth;

        

        //Property for the amount of stamina and previous position  
        public int Stamina { get; set; }

        public Rectangle PrevPos { get; set; }

        //Properties/fields that will be used for the sprite sheet animations
        public Texture2D Texture { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        private int currentFrame;

        private int totalFrames;

        private int timeSinceLastFrame = 0;

        private int millisecondsPerFrame = 50;

        public void Center()
        {
            position.X = windowWidth / 2;
            position.Y = windowHeight / 2;
        }

        public Player(Texture2D texture, Rectangle position, int width, int height, int rows, int columns) : base(texture, position)
        {            
            Stamina = 100;
            windowWidth = width;
            windowHeight = height;
            PrevPos = position;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {
            //Moves the player based on key presses
            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Up))
            {
                position.Y -= 5;                
            }
            if (kbState.IsKeyDown(Keys.Down))
            {
                position.Y += 5;
            }
            if (kbState.IsKeyDown(Keys.Left))
            {
                position.X -= 5;
            }
            if (kbState.IsKeyDown(Keys.Right))
            {
                position.X += 5;
            }


            //Prevents player from going off the screen from the bottom or right
            if(position.Y >= 1450)
            {
                position.Y = 1449;
            }
            if (position.X >= 1450)
            {
                position.X = 1449;
            }

            //Prevents the player from going off the screen from the top or left
            if (position.Y <= 0)
            {
                position.Y = 1;
            }
            if (position.X <= 0)
            {
                position.X = 1;
            }

            //Update logic for the frames of the sprite sheet, moves the current frame up by one once the time since last frame is greater than the limit for milliseconds per frame
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame++;

                //Resets the time since last frame
                timeSinceLastFrame = 0;

                if(currentFrame == totalFrames)
                {
                    //Resets the current frame back to zero once it reaches the total frames
                    currentFrame = 0;
                }
            }
        }

        public override void Draw(SpriteBatch sb, Vector2 loc)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float) currentFrame /Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)loc.X, (int)loc.Y, width, height);
            

            sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}
