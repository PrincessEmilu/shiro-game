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
    static class Helpers
    {
        //Single key press- return if the key was simply a single key press instead of currently being down
        static public bool SingleKeyPress(Keys key, KeyboardState pbState, KeyboardState kbState)
        {
            if (kbState.IsKeyDown(key) && (pbState.IsKeyUp(key) || pbState == null))
            {
                return true;
            }
            return false;
        }
    }
}
