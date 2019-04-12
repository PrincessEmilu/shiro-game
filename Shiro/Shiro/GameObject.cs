using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shiro
{
    abstract class GameObject
    {
        //Fields, a texture for the object and rectangle for the position of the object
        protected Texture2D texture;
        protected Rectangle position;

        //Property for the position field
        public Rectangle Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }

        //Allows for quickly getting 
        public int X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public int Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        //Constructor that takes two parameters
        protected GameObject(Texture2D texture, int xPosition, int yPosition)
        {
            this.texture = texture;
            position = new Rectangle(xPosition, yPosition, texture.Width, texture.Height);
        }

        //Draw method
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }

        public virtual void Draw(SpriteBatch sb, float opacity)
        {
            sb.Draw(texture, position, Color.White * opacity);
        }

        public abstract void Update(GameTime gameTime);
    }
}
