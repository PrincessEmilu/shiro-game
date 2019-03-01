using System;
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
        public MapPreviewer(Image tiles, int tileCounter, int backgroundTile, int sizeOfTiles)
        {
            InitializeComponent();
            this.tiles = tiles;
            this.tileCounter = tileCounter;
            this.backgroundTile = backgroundTile;
            this.sizeOfTiles = sizeOfTiles;
            tilesCropped = croppedImages(tiles);
        }

        private List<Image> croppedImages(Image tiles)
        {
            List<Image> listOfImages = new List<Image>(tileCounter);
            Bitmap imgCloned = (Bitmap)tiles;
            for(int i = 0; i < tileCounter; i++)
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
    }
}
