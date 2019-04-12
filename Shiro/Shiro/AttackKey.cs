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
        public AttackKey(Texture2D texture, int xPosition, int yPosition, Keys key, int speed) : base(texture, xPosition, yPosition)
        {
            this.speed = speed;
            KeyType = key;

            position.Width /= 10;
            position.Height /= 10;
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
    }
}
