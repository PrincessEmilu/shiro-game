using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace levelEditor
{
    public partial class LevelViewer : Form
    {
        //Fields
        Random rng = new Random();

        List<Image> listTiles;
        MapPanel[,] mapPanels;

        const string outputFileName = "myMap.txt";

        //Properties
        public int Paintbrush { get; set; }

        public LevelViewer()
        {
            InitializeComponent();

            //TODO: Actually let user select the tile
            Paintbrush = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Generate generate = new Generate(this);
            generate.ShowDialog();
        }

        //Method for generating the new map
        public void GenerateMap(
            Image tileset,
            int tilesInImage,
            int tileWidth, 
            int tileHeight, 
            int tilesPerScreenWidth, 
            int tilesPerScreenHeight, 
            int screensHorizontal,
            int screensVertical)
        {

            //Crops supplied image into a list of images (tileset)
            listTiles = CroppedImage(tileset, tilesInImage, tileWidth);

            //Total array sizes
            int gridPanelWidth = tilesPerScreenWidth * screensHorizontal;
            int gridPanelHeight = tilesPerScreenHeight * screensVertical;


            //Generate the map
            mapPanels = new MapPanel[gridPanelWidth, gridPanelHeight];

            for(int j = 0; j < gridPanelHeight; j ++)
            {
                for(int i = 0; i < gridPanelWidth; i ++)
                {
                    mapPanels[i, j] = new MapPanel();
                    mapPanels[i, j].Location = new Point(i * tileWidth, j * tileHeight + toolbarMain.Height);
                    mapPanels[i, j].Size = new Size(tileWidth, tileHeight);
                    mapPanels[i, j].BackgroundImage = listTiles[0];
                    mapPanels[i, j].tileID = 0;

                    mapPanels[i, j].Click += new EventHandler(NextTile);

                    Controls.Add(mapPanels[i, j]);
                }
            }

            //Create the paintbox
            Paintbox paintbox = new Paintbox(this, listTiles, tileset, tileset.Width, tileset.Height, tileWidth);
            paintbox.Show();
            paintbox.TopMost = true;
        }

        //Crops images and sorts them into a list
        //Alexa figured out the general code for cropping an image.
        private List<Image> CroppedImage(Image tiles, int tilesInImage, int tileSize)
        {
            int tilesHorizontal = tiles.Width / tileSize;
            int tilesVertical = tiles.Height / tileSize;

            List<Image> listOfImages = new List<Image>(tilesInImage);

            if (tiles != null)
            {
                Bitmap imgCloned = (Bitmap)tiles;

                //i columns, j rows
                for (int j = 0; j < tilesVertical; j++)
                {
                    for (int i = 0; i < tilesHorizontal; i++)
                    {
                        Rectangle cropRectangle = new Rectangle(tileSize * i, tileSize * j, tileSize, tileSize);
                        Bitmap newBitmap = imgCloned.Clone(cropRectangle, imgCloned.PixelFormat);
                        listOfImages.Add(newBitmap);
                    }
                }
            }
            Console.WriteLine(listOfImages.Count);
            return listOfImages;
        }

        //Changes panel to next tile
        private void NextTile(object sender, EventArgs e)
        {
            ((Panel)sender).BackgroundImage = listTiles[Paintbrush];
            ((MapPanel)sender).tileID = Paintbrush;

        }

        //Saves the map as a text file
        private void SaveMap()
        {
            if (mapPanels != null)
            {
                StreamWriter output = new StreamWriter(outputFileName);
                //Write a header here
                //TODO: Header should have info about the map, such as total size
                //Could also specify the tileset

                //Read array of panels
                for (int j = 0; j < mapPanels.GetLength(1); j++)
                {
                    for (int i = 0; i < mapPanels.GetLength(0); i++)
                    {
                        //Write the value of the map panel
                        output.Write(mapPanels[i, j].tileID + ",");
                    }

                    output.WriteLine();
                }

                output.Close();
            }
            else
            {
                ErrorMessage saveError = new ErrorMessage("Error: You don't have a level to save!");
                saveError.ShowDialog();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveMap();
        }
    }
}
