using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shiro
{
    //Enum for Key Type
    enum KeyType
    {
        Up,
        Down,
        Left,
        Right
    }

    class AttackKey : GameObject
    {
        //Fields
        KeyType key;
        int speed;

        //Constructor
        public AttackKey(Texture2D texture, Rectangle position, KeyType key, int speed) : base(texture, position)
        {
            this.key = key;
            this.speed = speed;
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
            switch (key)
            {
                case KeyType.Up:
                    sb.Draw(texture, position, null, Color.White, 0, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 1.0f);
                    break;
                case KeyType.Down:
                    sb.Draw(texture, position, null, Color.White, 0, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.FlipVertically, 1.0f);
                    break;
                case KeyType.Left:
                    sb.Draw(texture, position, null, Color.White, (float)(3*Math.PI/2), new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 1.0f);
                    break;
                case KeyType.Right:
                    sb.Draw(texture, position, null, Color.White, (float)(Math.PI / 2), new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 1.0f);
                    break;
                default:
                    break;
            }
        }
    }
}
