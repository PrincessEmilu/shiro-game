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
            set { position = value; }
        }

        //Constructor that takes two parameters
        protected GameObject(Texture2D texture, Rectangle position)
        {
            this.texture = texture;
            this.position = position;
        }

        //Draw method
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }

        public abstract void Update(GameTime gameTime);
    }
}
