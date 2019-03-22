using System;
using System.Collections.Generic;
using System.IO;
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
        //Metadata
        int levelNumber;

        //Data for what to spawn/draw
        List<GameObject> listEntities;
        int[,] mapTiles;

        //Assets
        Texture2D backgroundImage;
        Texture2D tilesetImage;

        //Sizing/positioning
        int levelWidth;
        int levelHeight;

        //Spawn is for when the player enters the are from the begnining; B is when returning from later screen
        Point playerSpawnA;
        Point playerSpawnB;

        public Level(int levelNumber)
        {
            string fileName = "level" + levelNumber + ".txt";
            LoadFromFile(fileName);
        }

        private void LoadFromFile(string fileName) //May consider a return type for if the level isn't loaded? Does that matter?
        {
            StreamReader input = new StreamReader(fileName);

            //Reads in level dimensions and creates array in correct size
            levelWidth = int.Parse(input.ReadLine());
            levelHeight = int.Parse(input.ReadLine());

            mapTiles = new int[levelWidth, levelHeight];

            //Nested for loop will read each line and parse it into the 2D array
            string fullLine;
            string[] splitLine;

            for (int j = 0; j < levelHeight; j++)
            {
                //Reads a row and saves it into a 1D array.
                fullLine = input.ReadLine();
                splitLine = fullLine.Split(',');

                for(int i = 0; i < levelWidth; i++)
                {
                    //Stores each value in the 1D array into the tilemap 2D array.
                    mapTiles[i, j] = int.Parse(splitLine[i]);
                }
            }

            input.Close();

        }

        public void Draw()
        {

        }
    }
}
