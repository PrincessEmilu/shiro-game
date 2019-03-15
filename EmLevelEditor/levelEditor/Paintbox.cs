using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace levelEditor
{
    public partial class Paintbox : Form
    {

        //Fields
        MapPanel[,] tilePanels;
        List<Image> listImages;
        LevelViewer mainForm;
        int tileSize;
        int arrayHeight;
        int arrayWidth;

        public Paintbox(LevelViewer mainForm, List<Image> listImages, Image tileSet, int width, int height, int tileSize)
        {
            InitializeComponent();

            //Init variables
            Width = width;
            Height = height;
            this.tileSize = tileSize;
            this.mainForm = mainForm;
            this.tileSize = tileSize;
            this.listImages = listImages;

             arrayWidth = tileSet.Width / tileSize;
             arrayHeight = tileSet.Height / tileSize;

            tilePanels = new MapPanel[arrayWidth, arrayHeight];
            for (int j = 0; j < arrayHeight; j++)
            {
                for (int i = 0; i < arrayWidth; i++)
                {
                    tilePanels[i, j] = new MapPanel();
                    tilePanels[i, j].Location = new Point(i * tileSize, j * tileSize);
                    tilePanels[i, j].Size = new Size(tileSize, tileSize);
                    tilePanels[i, j].BackgroundImage = listImages[i + j * arrayWidth];
                    tilePanels[i, j].tileID = i + j * arrayWidth;

                    //Adds event handler
                    tilePanels[i, j].Click += new EventHandler(TileSelect);

                    Controls.Add(tilePanels[i, j]);
                }
            }
        }

        //Selects the tile to paint with
        private void TileSelect(object sender, EventArgs e)
        {
            ((MapPanel)sender).BorderStyle = BorderStyle.FixedSingle;
            mainForm.Paintbrush = ((MapPanel)sender).tileID;
        }
    }
}
