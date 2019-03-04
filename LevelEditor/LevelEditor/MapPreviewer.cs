using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class MapPreviewer : Form
    {
        List<Image> tilesCropped;
        Image tiles;
        int tileCounter;
        int backgroundTile;
        int sizeOfTiles;
        List<Button> grid;
        public MapPreviewer(Image tiles, int tileCounter, int backgroundTile, int sizeOfTiles)
        {
            InitializeComponent();
            this.tiles = tiles;
            this.tileCounter = tileCounter;
            this.backgroundTile = backgroundTile;
            this.sizeOfTiles = sizeOfTiles;
            tilesCropped = croppedImages(tiles);
            grid = new List<Button>(144);
        }

        private List<Image> croppedImages(Image tiles)
        {
            List<Image> listOfImages = new List<Image>(tileCounter);
            Bitmap imgCloned = (Bitmap)tiles;
            for (int i = 0; i < tileCounter; i++)
            {
                Rectangle cropRectangle = new Rectangle(sizeOfTiles * i, 0, sizeOfTiles, sizeOfTiles);
                Bitmap newBitmap = imgCloned.Clone(cropRectangle, imgCloned.PixelFormat);
                listOfImages.Add(newBitmap);
            }
            return listOfImages;
        }

        private void tableLayoutPixels_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.DrawImage(tilesCropped[backgroundTile - 1], e.CellBounds);
        }

        private void MapPreviewer_Load(object sender, EventArgs e)
        {
            int ButtonWidth = sizeOfTiles / 2;
            int ButtonHeight = sizeOfTiles / 2;
            int Distance = 20;
            int start_x = 10;
            int start_y = 10;
            int baseTileIndex = backgroundTile - 1;

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    Button tmpButton = new Button();
                    tmpButton.Top = start_x + (x * ButtonHeight + Distance);
                    tmpButton.Left = start_y + (y * ButtonWidth + Distance);
                    tmpButton.Width = ButtonWidth;
                    tmpButton.Height = ButtonHeight;
                    tmpButton.FlatAppearance.BorderSize = 0;
                    tmpButton.BackgroundImage = tilesCropped[baseTileIndex];
                    this.Controls.Add(tmpButton);
                    tmpButton.Click += new EventHandler(button_Click);
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            b.BackgroundImage = tilesCropped[backgroundTile];
        }
    }
}
