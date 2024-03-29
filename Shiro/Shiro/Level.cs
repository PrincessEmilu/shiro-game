﻿using System;
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
        string fileName;

        //Data for what to spawn/draw
        int[,] mapTiles;
        List<CollisionItem> collisionList;

        //Assets
        Texture2D tilesetImage;
        Texture2D doorTexture;

        //Sizing/positioning
        int levelWidth;
        int levelHeight;

        //Information about tiles from file
        int tileSize;
        int tilesPerRow;
        int tilesPerColumn;

        //Player object needed for collidable objects
        Player player;

        //Properties
        public List<CollisionItem> CollisonList { get { return collisionList; } }

        public int LevelWidthPixels { get; private set; }
        public int LevelHeightPixels { get; private set; }

        public Level(int levelNumber, Texture2D tileset, Texture2D doorTexture, Player player)
        {
            //Init variables
            collisionList = new List<CollisionItem>();

            tilesetImage = tileset;
            this.doorTexture = doorTexture;

            this.levelNumber = levelNumber;
            this.player = player;

            //Base filename...
            fileName = "level" + levelNumber + ".txt";

            //Cocantenate the directory path
            string originalLoc = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            fileName = (Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(originalLoc).FullName).FullName).FullName).FullName).FullName)
            + ("\\Levels\\" + fileName);

            //Now loads it from file
            LoadFromFile(fileName);
        }

        private void LoadFromFile(string fileName) //May consider a return type for if the level isn't loaded? Does that matter?
        {
            StreamReader input = new StreamReader(fileName);

            //Reads in level dimensions and creates array in correct size
            levelWidth = int.Parse(input.ReadLine());
            levelHeight = int.Parse(input.ReadLine());
            tileSize = int.Parse(input.ReadLine());

            LevelWidthPixels = levelWidth * tileSize;
            LevelHeightPixels = levelHeight * tileSize;

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

            //This loop functions the same as above, but creates a list of collision items
            for (int j = 0; j < levelHeight; j++)
            {
                //Reads a row and saves it into a 1D array.
                fullLine = input.ReadLine();
                splitLine = fullLine.Split(',');

                for (int i = 0; i < levelWidth; i++)
                {
                    //Conceptually, this section of code should add a new collision item to the list of collision items,
                    //specifiying its position (and maybe eventually, other properites)
                    if (bool.Parse(splitLine[i]))
                    {
                        collisionList.Add(new CollisionItem(tilesetImage, tileSize * i, tileSize * j, player));
                    }
                    
                }
            }

            //Calculates tiles per row for drawing the correct section of hte sprite sheet
            tilesPerRow = tilesetImage.Width / tileSize;
            tilesPerColumn = tilesetImage.Height / tileSize;

            input.Close();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw every collidable object
            foreach (CollisionItem collisionItem in collisionList)
            {
                collisionItem.Draw(spriteBatch, false);
            }

            //Draws every tile in the array
            for (int j = 0; j < levelHeight; j++)
            {
                for(int i = 0; i < levelWidth; i++)
                {
                    int tileID = mapTiles[i, j];

                    //Calculated offset tells the draw method where to find the right tile from the tile set
                    int xOffset = (tileID % tilesPerRow) * tileSize;
                    int yOffset = (tileID/tilesPerRow) * tileSize;


                    spriteBatch.Draw(
                        tilesetImage, //Image
                        new Vector2(i * tileSize, j * tileSize), //Spot on the screen
                        new Rectangle(xOffset, yOffset, tileSize, tileSize), //Section of the image to draw
                        Color.White); //Blend
                }
            }
        }
    }
}
