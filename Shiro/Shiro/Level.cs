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
    class Level
    {
        //Data for what to spawn/draw
        List<GameObject> listEntities;
        int[] mapTiles;

        //Assets
        Texture2D backgroundImage;
        Texture2D tilesetImage;

        //Sizing/positioning
        int levelWidth;
        int levelHeight;

        //Spawn is for when the player enters the are from the begnining; B is when returning from later screen
        Point playerSpawnA;
        Point playerSpawnB;

        public Level()
        {

        }

        private void LoadFromFile() //May consider a return type for if the level isn't loaded? Does that matter?
        {

        }

        public void Draw()
        {

        }
    }
}
