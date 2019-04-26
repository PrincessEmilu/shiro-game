using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Shiro
{
    class HealingBox : GameObject
    {
        //Fields, a texture for the object and rectangle for the position of the object
        private Texture2D texture;
        private Rectangle position;

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
        public HealingBox(Texture2D texture, int xPosition, int yPosition) : base(texture, xPosition, yPosition)
        {
            this.texture = texture;
            position = new Rectangle(xPosition, yPosition, 100, 100);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }

        public override void Update(GameTime gameTime)
        {

        }

        //Check Collison
        public bool CheckCollision(GameObject check)
        {
            //Active can be added again if this becomes a pickup and not a save space
            //if (Active == true)
            //{
                if (position.Intersects(check.Position)) //check if intersecting with the player
                {
                    return true;
                }
           // }
           //else
           // {
                return false;
           // }

        }
    }
}
