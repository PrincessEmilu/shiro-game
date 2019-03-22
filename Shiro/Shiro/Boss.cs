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
    enum AttackPattern
    {
        Pattern1,
        Pattern2
    }

    class Boss : Enemy
    {
        //Fields
        private AttackPattern pattern;
        private List<Texture2D> animations;


        //Properties
        public AttackPattern Pattern
        {
            get { return pattern; }
            set { pattern = value; }
        }

        //Constructor
        public Boss(Texture2D texture, Rectangle position, int width, int height, Random rng, List<Texture2D> animations) : base(texture, position, width, height, rng)
        {
            this.animations = animations;
            pattern = AttackPattern.Pattern1;
            
        }

        public override void Update(GameTime gameTime)
        {
            //To Make Sure the Boss Does Not Move
        }
    }
}
