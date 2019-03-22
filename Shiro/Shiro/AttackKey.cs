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

    class AttackKey : GameObject
    {
        //Fields
        int speed;

        //Properties
        public Keys KeyType { get; protected set; }

        //Constructor
        public AttackKey(Texture2D texture, Rectangle position, Keys key, int speed) : base(texture, position)
        {
            this.speed = speed;
            KeyType = key;
        }

        public override void Update(GameTime gameTime)
        {
            position.X -= (speed * 1);
        }

        public bool CheckCollison(Rectangle area)
        {
            if (position.Intersects(area))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            switch (KeyType)
            {
                case Keys.Up:
                    sb.Draw(texture, position, null, Color.White, 0, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0.9f);
                    break;
                case Keys.Down:
                    sb.Draw(texture, position, null, Color.White, 0, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.FlipVertically, 1.0f);
                    break;
                case Keys.Left:
                    sb.Draw(texture, position, null, Color.White, (float)(3*Math.PI/2), new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 1.0f);
                    break;
                case Keys.Right:
                    sb.Draw(texture, position, null, Color.White, (float)(Math.PI / 2), new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0.9f);
                    break;
                default:
                    break;
            }
        }
    }
}
