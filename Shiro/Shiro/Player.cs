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
        private bool topBounding;
        private bool bottomBounding;
        private bool rightBounding;
        private bool leftBounding;

        private int frame;

        public Camera camera;

        public Rectangle boundBox;

        Texture2D box;

        //Property for the amount of stamina and previous position  
        public int Stamina { get; set; }

        public Rectangle PrevPos { get; set; }        

        public Rectangle BoxPrevPos { get; set; }

        public int BoundBoxY
        {
            get {return boundBox.Y; }
            set
            {
                boundBox.Y = value;
            }
        }

        public int BoundBoxX
        {
            get { return boundBox.X; }
            set
            {
                boundBox.X = value;
            }
        }

        public void Center()
        {
            position.X = windowWidth / 2;
            position.Y = windowHeight / 2;
        }

        public Player(Texture2D texture, Rectangle position, int width, int height, Camera camera, Texture2D box, Rectangle boundBox) : base(texture, position)
        {
            frame = 0;
            Stamina = 100;
            windowWidth = width;
            windowHeight = height;
            PrevPos = position;
            this.camera = camera;
            this.boundBox = boundBox;
            this.box = box;
            topBounding = false;
            bottomBounding = false;
            rightBounding = false;
            leftBounding = false;
        }

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {
            //Moves the player based on key presses
            KeyboardState kbState = Keyboard.GetState();

            //Prevents player from going out of the boundbox

            if (position.Bottom + 100 >= boundBox.Bottom)
            {
                bottomBounding = true;
            }
            else
            {
                bottomBounding = false;
            }

            if (position.Right + 100 >= boundBox.Right)
            {
                rightBounding = true;
            }
            else
            {
                rightBounding = false;
            }

            if (position.Top - 100 <= boundBox.Top)
            {
                topBounding = true;
            }
            else
            {
                topBounding = false;
            }

            if (position.Left - 100 <= boundBox.Left)
            {
                leftBounding = true;
            }
            else
            {
                leftBounding = false;
            }

            if (kbState.IsKeyDown(Keys.Up) && topBounding == false)
            {
                position.Y -= 5;

            }

            if (kbState.IsKeyDown(Keys.Down) && bottomBounding == false)
            {
                position.Y += 5;

            }

            if (kbState.IsKeyDown(Keys.Left) && leftBounding == false)
            {
                position.X -= 5;

            }
            if (kbState.IsKeyDown(Keys.Right) && rightBounding == false)
            {
                position.X += 5;

            }

            //Prevents bound box from going off screen
            if (boundBox.Right >= 1500)
            {
                boundBox.X = 900;
            }

            if (boundBox.Bottom >= 1500)
            {
                boundBox.Y = 900;
            }

            if (boundBox.Left <= 0)
            {
                boundBox.X = 1;
            }

            if (boundBox.Top <= 0)
            {
                boundBox.Y = 1;
            }

        }

        public override void Draw(SpriteBatch sb)
        {

            //Increase the frame, which will animate the player.
            int frameWidth = 550;
            int frameHeight = 400;

            //Calculates x/y offset to draw based on current frame and the tiles per row
            int xDrawOffset = frame % 7 * (frameWidth + 10);//frame % 7 * frameWidth;
            int yDrawOffest = frame / 7 * (frameHeight + 10);

            frame += 1;
            if (frame == 60) { frame = 0; }

            sb.Draw(
                texture,
                new Rectangle(position.X, position.Y, 180, 148),
                new Rectangle(xDrawOffset, yDrawOffest, 570, 440),
                Color.White);            
        }        
    }
}
