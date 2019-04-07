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
        Paintbox paintbox;

        int tileSize;

        const string outputFileName = "myMap.txt";

        //Properties
        public int Paintbrush { get; set; }

        public LevelViewer()
        {
            InitializeComponent();
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
            int tileSize,
            int tilesPerScreenWidth, 
            int tilesPerScreenHeight, 
            int screensHorizontal,
            int screensVertical)
        {
            //Instructions text goes away
            labelInstructions.Visible = false;
            labelInstructions.Enabled = false;

            //Tilesize variable saved for saving the file
            this.tileSize = tileSize;

            //Crops supplied image into a list of images (tileset)
            listTiles = CroppedImage(tileset, tileSize);

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
                    mapPanels[i, j].Location = new Point(i * tileSize, j * tileSize + toolbarMain.Height);
                    mapPanels[i, j].Size = new Size(tileSize, tileSize);
                    mapPanels[i, j].BackgroundImage = listTiles[0];
                    mapPanels[i, j].tileID = 0;

                    mapPanels[i, j].MouseClick += new MouseEventHandler(ClickTile);
                    mapPanels[i, j].BorderStyle = BorderStyle.FixedSingle;

                    Controls.Add(mapPanels[i, j]);
                }
            }

            //Create a paintbox- the tile-selector, essentially
            if (paintbox != null) { paintbox.Close(); }
            paintbox = new Paintbox(this, listTiles, tileset, tileset.Width, tileset.Height, tileSize);
            paintbox.Show();
            paintbox.TopMost = true;
        }

        //Crops images and sorts them into a list
        //Alexa figured out the general code for cropping an image.
        private List<Image> CroppedImage(Image tiles, int tileSize)
        {
            int tilesHorizontal = tiles.Width / tileSize;
            int tilesVertical = tiles.Height / tileSize;

            List<Image> listOfImages = new List<Image>();

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
            return listOfImages;
        }

        //Rightclick for placing collision
        public void RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Console.WriteLine("boop");
            }
        }

        //Changes the clicked tile to the paintbrush tile
        private void ClickTile(object sender, MouseEventArgs e)
        {

            //right click adds collision
            if (e.Button == MouseButtons.Right)
            {
                if (((MapPanel)sender).isCollision == true)
                {
                    Console.WriteLine(((MapPanel)sender).isCollision = false);
                    ((MapPanel)sender).BackColor = DefaultBackColor;
                }
                else
                {
                    Console.WriteLine(((MapPanel)sender).isCollision = true);
                    ((MapPanel)sender).BackColor = Color.Blue;
                }
            }
            //Left click paints tile
            else
            {
                ((Panel)sender).BackgroundImage = listTiles[Paintbrush];
                ((MapPanel)sender).tileID = Paintbrush;
            }

        }

        //Saves the map to a text file
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mapPanels != null)
            {

                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "level.txt";
                save.Filter = "Text File | *.txt";

                if (save.ShowDialog() == DialogResult.OK)
                {

                    StreamWriter output = new StreamWriter(save.FileName);

                    //Write file header- gives map info to level-drawing class
                    output.WriteLine(mapPanels.GetLength(0));
                    output.WriteLine(mapPanels.GetLength(1));
                    output.WriteLine(tileSize);


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

                    //Read array again, but this time maps collision
                    for (int j = 0; j < mapPanels.GetLength(1); j++)
                    {
                        for (int i = 0; i < mapPanels.GetLength(0); i++)
                        {
                            //Write the value of the colision
                            output.Write(mapPanels[i, j].isCollision + ",");
                        }

                        output.WriteLine();
                    }

                    output.Close();
                }
            }
            else
            {
                ErrorMessage saveError = new ErrorMessage("Error: You don't have a level to save!");
                saveError.ShowDialog();
            }
        }

        //User pressed load- load a file
        private void toolStripButtonLoad_onClick(object sender, EventArgs e)
        {
            //user prompted to open a file
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Map File";
            dlg.Filter = "png files (*.txt)|*.txt";

            //If that works, load the text file.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filePath = dlg.FileName;

                StreamReader input = new StreamReader(filePath);

                //Read header values 
                int levelWidth = int.Parse(input.ReadLine());
                int levelHeight = int.Parse(input.ReadLine());
                tileSize = int.Parse(input.ReadLine());

                int[,] tileIDArray = new int[levelWidth, levelHeight];
                bool[,] collideArray = new bool[levelWidth, levelHeight];

                //Nested for loop will read each line and parse it into the 2D array of tile IDs and collisions
                string fullLine;
                string[] splitLine;

                for (int j = 0; j < levelHeight; j++)
                {
                    //Reads a row and saves it into a 1D array.
                    fullLine = input.ReadLine();
                    splitLine = fullLine.Split(',');

                    for (int i = 0; i < levelWidth; i++)
                    {
                        //Stores each value in the 1D array into the tilemap 2D array.
                        tileIDArray[i, j] = int.Parse(splitLine[i]);
                    }
                }

                for (int j = 0; j < levelHeight; j++)
                {
                    //Reads a row and saves it into a 1D array.
                    fullLine = input.ReadLine();
                    splitLine = fullLine.Split(',');

                    for (int i = 0; i < levelWidth; i++)
                    {
                        //Stores each value in the 1D array into the tilemap 2D array.
                        collideArray[i, j] = bool.Parse(splitLine[i]);
                    }
                }

                input.Close();

                dlg.Dispose();

                Image tileSet;

                //Now, open the tileset
                dlg = new OpenFileDialog();
                dlg.Title = "Open Image";
                dlg.Filter = "png files (*.png)|*.png";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tileSet = Image.FromFile(dlg.FileName);

                    //Crops supplied image into a list of images (tileset)
                    listTiles = CroppedImage(tileSet, tileSize);

                    //Total array sizes
                    int gridPanelWidth = levelWidth;
                    int gridPanelHeight = levelHeight;


                    //Generate the map
                    mapPanels = new MapPanel[gridPanelWidth, gridPanelHeight];

                    for (int j = 0; j < gridPanelHeight; j++)
                    {
                        for (int i = 0; i < gridPanelWidth; i++)
                        {
                            mapPanels[i, j] = new MapPanel();
                            mapPanels[i, j].Location = new Point(i * tileSize, j * tileSize + toolbarMain.Height);
                            mapPanels[i, j].Size = new Size(tileSize, tileSize);
                            mapPanels[i, j].BackgroundImage = listTiles[tileIDArray[i, j]];

                            mapPanels[i, j].tileID = tileIDArray[i, j];
                            //Sets collide status, changes color if it's true
                            if (mapPanels[i, j].isCollision = collideArray[i, j])
                            { mapPanels[i, j].BackColor = Color.Blue; }

                            mapPanels[i, j].MouseClick += new MouseEventHandler(ClickTile);
                            mapPanels[i, j].BorderStyle = BorderStyle.FixedSingle;

                            Controls.Add(mapPanels[i, j]);
                        }
                    }

                    //Instructions text goes away
                    labelInstructions.Visible = false;
                    labelInstructions.Enabled = false;

                    //Create a paintbox- the tile-selector, essentially
                    if (paintbox != null) { paintbox.Close(); }
                    paintbox = new Paintbox(this, listTiles, tileSet, tileSet.Width, tileSet.Height, tileSize);
                    paintbox.Show();
                    paintbox.TopMost = true;
                }
                dlg.Dispose();
            }
            dlg.Dispose();


        }

        private void LevelViewer_Load(object sender, EventArgs e)
        {

        }

        private void LevelViewer_Load_1(object sender, EventArgs e)
        {

        }
    }
}
