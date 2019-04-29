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
    //Playerstate
    enum PlayerState
    {
        FaceLeft,
        FaceRight,
        WalkLeft,
        WalkRight
    }
    class Player : GameObject
    {       
        #region Fields
        private int windowHeight;
        private int windowWidth;
        private bool topBounding;
        private bool bottomBounding;
        private bool rightBounding;
        private bool leftBounding;

        int movementSpeed;

        private List<CollisionItem> itemsColliding;

        private int frame;

        public Camera camera;

        public Rectangle boundBox;

        Texture2D box;
        Texture2D walkTexture;
        #endregion

        #region Properties
        //Properties
        public int Stamina { get; set; }

        public Rectangle PrevPos { get; set; } 
        
        public Rectangle Pos
        {
            set { position = value; }
        }

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

        //World size for bounding box
        public int WorldWidth { get; set; }
        public int WorldHeight { get; set; }


        public bool TopWall { get; private set; }
        public bool BottomWall { get; private set; }
        public bool LeftWall { get; private set; }
        public bool RightWall { get; private set; }

        public Color BlendColor { get; set; }

        public List<CollisionItem> ItemsColliding
        {
            get { return itemsColliding; }
            set { itemsColliding = value; }
        }

        //Current game state
        public PlayerState CurrentState { get; set; }
        #endregion

        #region Constructor
        //Constructor
        public Player(Texture2D texture, Texture2D walkTexture, int xPosition, int yPosition, int width, int height, int movementSpeed, Camera camera, 
            Texture2D box, Rectangle boundBox, List<CollisionItem> listCollisions) : base(texture, xPosition, yPosition)
        {
            CurrentState = PlayerState.FaceLeft;

            BlendColor = Color.White;
            this.movementSpeed = movementSpeed;
            frame = 0;
            Stamina = 100;
            this.walkTexture = walkTexture;
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
            itemsColliding = listCollisions;

            //Set collision box width to be the target box width/height for the object
            position.Width = 180;
            position.Height = 148;
        }
        #endregion

        //Overridden Update method, puts all of the player's update code into one place to be called once
        public override void Update(GameTime gameTime)
        {

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

            if (position.Top - 125 <= boundBox.Top)
            {
                topBounding = true;
            }
            else
            {
                topBounding = false;
            }

            if (position.Left - 130 <= boundBox.Left)
            {
                leftBounding = true;
            }
            else
            {
                leftBounding = false;
            }

            //Player movement
            
            if (CurrentState != PlayerState.FaceLeft && CurrentState != PlayerState.FaceRight)
            {
                if (kbState.IsKeyDown(Keys.Up) && topBounding == false)
                {
                    bool canContinue = true;

                    foreach (CollisionItem solidObject in itemsColliding)
                    {
                        //if (CheckCollisions(solidObject)) { canContinue = false; }
                    }

                    if (canContinue) { position.Y -= movementSpeed; }
                }

                if (kbState.IsKeyDown(Keys.Down) && bottomBounding == false)
                {
                    position.Y += movementSpeed;
                }

                if (kbState.IsKeyDown(Keys.Left) && leftBounding == false)
                {
                        position.X -= movementSpeed;
                }
                
                if (kbState.IsKeyDown(Keys.Right) && rightBounding == false)
                {
                        position.X += movementSpeed;
                }
            }

            //Prevents bound box from going off screen
            if (boundBox.Right >= WorldWidth)
            {
                boundBox.X = WorldWidth - boundBox.Width;
            }

            if (boundBox.Bottom >= WorldHeight)
            {
                boundBox.Y = WorldHeight - boundBox.Height;
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

        //Updates the player's animation state
        public void UpdateAnimation(KeyboardState kbState)
        {
            //Check the current state first.
            switch (CurrentState)
            {
                case PlayerState.FaceRight:

                    if (kbState.IsKeyDown(Keys.Up) && kbState.IsKeyDown(Keys.Down) && (!kbState.IsKeyDown(Keys.Right) || !kbState.IsKeyDown(Keys.Left)))
                    {
                        CurrentState = PlayerState.FaceRight;
                        break;
                    }
                    else if (kbState.IsKeyDown(Keys.Right) && kbState.IsKeyDown(Keys.Left) && (!kbState.IsKeyDown(Keys.Up) || !kbState.IsKeyDown(Keys.Down)))
                    {
                        CurrentState = PlayerState.FaceRight;
                        break;
                    }
                    else if (kbState.IsKeyDown(Keys.Right) && !kbState.IsKeyDown(Keys.Left))
                    {
                        CurrentState = PlayerState.WalkRight;
                        break;
                    }
                    else if ((kbState.IsKeyDown(Keys.Up) || kbState.IsKeyDown(Keys.Down)) && !kbState.IsKeyDown(Keys.Left))
                    {
                        CurrentState = PlayerState.WalkRight;
                        break;
                    }
                    else if (kbState.IsKeyDown(Keys.Left) && !kbState.IsKeyDown(Keys.Right))
                        CurrentState = PlayerState.FaceLeft;

                    break;

                case PlayerState.FaceLeft:

                    if (kbState.IsKeyDown(Keys.Up) && kbState.IsKeyDown(Keys.Down) && (!kbState.IsKeyDown(Keys.Right) || !kbState.IsKeyDown(Keys.Left)))
                    {
                        CurrentState = PlayerState.FaceLeft;
                        break;
                    }
                    else if (kbState.IsKeyDown(Keys.Right) && kbState.IsKeyDown(Keys.Left) && (!kbState.IsKeyDown(Keys.Up) || !kbState.IsKeyDown(Keys.Down)))
                    {
                        CurrentState = PlayerState.FaceLeft;
                        break;
                    }
                    else if (kbState.IsKeyDown(Keys.Left) && !kbState.IsKeyDown(Keys.Right))
                    {
                        CurrentState = PlayerState.WalkLeft;
                        break;
                    }
                    else if ((kbState.IsKeyDown(Keys.Up) || kbState.IsKeyDown(Keys.Down)) && !kbState.IsKeyDown(Keys.Right))
                    {
                        CurrentState = PlayerState.WalkLeft;
                        break;
                    }
                    else if (kbState.IsKeyDown(Keys.Right) && !kbState.IsKeyDown(Keys.Left))
                        CurrentState = PlayerState.FaceRight;
                    break;

                case PlayerState.WalkLeft:
                    if (kbState.IsKeyDown(Keys.Up) && kbState.IsKeyDown(Keys.Down) && (!kbState.IsKeyDown(Keys.Right) || !kbState.IsKeyDown(Keys.Left)))
                    {
                        CurrentState = PlayerState.FaceLeft;
                    }
                    else if (kbState.IsKeyDown(Keys.Right) && kbState.IsKeyDown(Keys.Left) && (!kbState.IsKeyDown(Keys.Up) || !kbState.IsKeyDown(Keys.Down)))
                    {
                        CurrentState = PlayerState.FaceLeft;
                        break;
                    }
                    else if (kbState.IsKeyDown(Keys.Right))
                    {
                        CurrentState = PlayerState.FaceLeft;
                    }
                    else if (!kbState.IsKeyDown(Keys.Left) && !kbState.IsKeyDown(Keys.Up) && !kbState.IsKeyDown(Keys.Down))
                    {
                        CurrentState = PlayerState.FaceLeft;
                    }
                    break;
                case PlayerState.WalkRight:
                    if (kbState.IsKeyDown(Keys.Up) && kbState.IsKeyDown(Keys.Down) && (!kbState.IsKeyDown(Keys.Right) || !kbState.IsKeyDown(Keys.Left)))
                    {
                        CurrentState = PlayerState.FaceRight;
                    }
                    else if (kbState.IsKeyDown(Keys.Right) && kbState.IsKeyDown(Keys.Left) && (!kbState.IsKeyDown(Keys.Up) || !kbState.IsKeyDown(Keys.Down)))
                    {
                        CurrentState = PlayerState.FaceRight;
                        break;
                    }
                    else if (kbState.IsKeyDown(Keys.Left))
                    {
                        CurrentState = PlayerState.FaceLeft;
                    }
                    else if (!kbState.IsKeyDown(Keys.Right) && !kbState.IsKeyDown(Keys.Up) && !kbState.IsKeyDown(Keys.Down))
                    {
                        CurrentState = PlayerState.FaceRight;
                    }
                    break;
            }
        }

        //Draws the player
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

            //Draw different sprite based on state
            switch (CurrentState)
            {
                case PlayerState.FaceRight:
                    //public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
                    sb.Draw(
                        texture,                                                //Texture to draw
                        new Rectangle(position.X, position.Y, 180, 148),        //Rectangle to draw to
                        new Rectangle(xDrawOffset, yDrawOffest - 4, 570, 430),      //Source rectangle to draw from file
                        BlendColor,                                            //Blend color
                        0f,                                                     //Rotation
                        new Vector2(0,0),                                       //Origin
                        SpriteEffects.FlipHorizontally,                         //Sprite Effects
                        0f                                                      //Layer to draw on
                        );
                    break;
                case PlayerState.FaceLeft:
                    sb.Draw(
                        texture,                                                //Texture to draw
                        new Rectangle(position.X, position.Y, 180, 148),        //Rectangle to draw to
                        new Rectangle(xDrawOffset, yDrawOffest - 4, 570, 430),      //Source rectangle to draw from file
                        BlendColor);                                           //Blend color
                    break;
                case PlayerState.WalkRight:
                    sb.Draw(
                        walkTexture,
                        new Rectangle(position.X, position.Y, 180, 148),
                        new Rectangle(xDrawOffset, yDrawOffest - 4, 570, 430),
                        BlendColor,
                        0f,
                        new Vector2(0, 0),
                        SpriteEffects.FlipHorizontally,
                        0f
                        );
                    break;
                case PlayerState.WalkLeft:
                    sb.Draw(
                        walkTexture,
                        new Rectangle(position.X, position.Y, 180, 148),
                        new Rectangle(xDrawOffset, yDrawOffest - 4, 570, 430),
                        BlendColor);
                    break;
            }
        }
    }
}
