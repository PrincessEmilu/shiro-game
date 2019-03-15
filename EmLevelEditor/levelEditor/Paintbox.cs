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
        int arrayHeight;
        int arrayWidth;

        const int tileSize = 32;

        public Paintbox(LevelViewer mainForm, List<Image> listImages, Image tileSet, int width, int height, int nativeSize)
        {
            InitializeComponent();

            //Init variables
            this.mainForm = mainForm;
            this.listImages = listImages;

            arrayWidth = tileSet.Width / nativeSize;
            arrayHeight = tileSet.Height / nativeSize;

            //window dimensions
            Width = 32 * (arrayWidth + 1);
            Height = 32 * (arrayHeight +1);

            tilePanels = new MapPanel[arrayWidth, arrayHeight];

            for (int j = 0; j < arrayHeight; j++)
            {
                for (int i = 0; i < arrayWidth; i++)
                {
                    tilePanels[i, j] = new MapPanel();
                    tilePanels[i, j].BackgroundImage = new Bitmap(listImages[i + j * arrayWidth], new Size(tileSize, tileSize));
                    tilePanels[i, j].Location = new Point(i * tileSize, j * tileSize);
                    tilePanels[i, j].Size = new Size(tileSize, tileSize);
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

        private void Paintbox_Load(object sender, EventArgs e)
        {

        }
    }
}
