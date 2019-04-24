using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiro
{
    class CollisionItem
    {
        //variables
        Texture2D texture;
        int xPos, yPos, xPosInNewLevel, yPosInNewLevel;
        Level levelNext;
        Rectangle collisionBox;
        GameObject objToCollide;

        public event playerCollided playerHit;

        public bool IsDoor { get; private set; }

        public Rectangle Position
        {
            get { return collisionBox; }
        }
        //any collsion
        public CollisionItem(Texture2D texture, int xPos, int yPos, GameObject objToCollide)
        {
            this.texture = texture;
            this.xPos = xPos;
            this.yPos = yPos;
            this.objToCollide = objToCollide;

            collisionBox = new Rectangle(xPos, yPos, texture.Width, texture.Height);
        }

        //any collsion, no drawing
        public CollisionItem( int xPos, int yPos, GameObject objToCollide)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.objToCollide = objToCollide;

            //collisionBox = new Rectangle(xPos, yPos, texture.Width, texture.Height);
        }

        //collision is a door
        public CollisionItem(Texture2D texture, int xPos, int yPos, GameObject objToCollide, Level levelNext, int xPosInNewLevel, int yPosInNewLevel)
        {
            this.texture = texture;
            this.xPos = xPos;
            this.yPos = yPos;
            this.objToCollide = objToCollide;

            this.levelNext = levelNext;
            this.xPosInNewLevel = xPosInNewLevel;
            this.yPosInNewLevel = yPosInNewLevel;

            collisionBox = new Rectangle(xPos, yPos, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime, bool isDoor)
        {
            IsDoor = isDoor;

            //if true and not a door
            if(CheckCollision(objToCollide) && !isDoor)
            {

            }
            //if true but is a door
            else if (isDoor)
            {

            }
        }

        public bool CheckCollision(GameObject obj)
        {
            //if the player's box collides with collision box
            if(collisionBox.Intersects(obj.Position)) {
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch sb, bool isDoor)
        {
            //Only tries to draw if there is a texture
            if (texture != null)
            {
                //if true and not a door
                if (CheckCollision(objToCollide) && !isDoor)
                {
                    sb.Draw(texture, collisionBox, Color.Red);
                }
                //if true but is a door
                else if (isDoor)
                {
                    sb.Draw(texture, collisionBox, Color.White);
                }
                //draw it normally at it's rectangle position
                else
                {
                    sb.Draw(texture, collisionBox, Color.White);
                }
            }
        }

        public Rectangle CollisionBox
        {
            get
            {
                return collisionBox;
            }
        }
    }
}
