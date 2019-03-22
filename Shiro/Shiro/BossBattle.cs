using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shiro
{
    class BossBattle : Battle
    {
        public BossBattle(KeyboardState kbState, KeyboardState pbState, SpriteFont font, Texture2D keyTexture, Texture2D hitboxTexture, Player player, Boss enemy) 
            : base(kbState, pbState, font, keyTexture, hitboxTexture, player, enemy)
        {

        }

        //OVerride the 
    }
}
