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
        List<Button> map;
        Image tiles;
        int tileCounter;
        int paddingNum;
        int backgroundTile;
        int sizeOfTiles;
        public MapPreviewer(Image tiles, int tileCounter, int paddingNum, int backgroundTile, int sizeOfTiles)
        {
            InitializeComponent();
            this.tiles = tiles;
            this.tileCounter = tileCounter;
            this.paddingNum = paddingNum;
            this.backgroundTile = backgroundTile;
            this.sizeOfTiles = sizeOfTiles;
            map = new List<Button>(1280 * 720);
        }

        private void MapPreviewer_Load(object sender, EventArgs e)
        {
            int tileWidth = sizeOfTiles;
            int tileHeight = sizeOfTiles;
            int tileRows = 30;
            int tileCols = 30;

            using (Bitmap sourceBmp = new Bitmap(tiles))
            {
                Size s = new Size(tileWidth, tileHeight);
                Rectangle destRect = new Rectangle(Point.Empty, s);
                for (int row = 0; row < tileRows; row++)
                    for (int col = 0; col < tileCols; col++)
                    {
                        PictureBox p = new PictureBox();
                        p.Size = s;
                        Point loc = new Point(tileWidth * col, tileHeight * row);
                        Rectangle srcRect = new Rectangle(loc, s);
                        Bitmap tile = new Bitmap(tileWidth, tileHeight);
                        Graphics G = Graphics.FromImage(tile);
                        G.DrawImage(sourceBmp, destRect, srcRect, GraphicsUnit.Pixel);
                        p.Image = tile;
                        p.Location = loc;
                        p.Tag = loc;
                        p.Name = String.Format("Col={0:00}-Row={1:00}", col, row);
                        // p.MouseDown += p_MouseDown;
                        // p.MouseUp += p_MouseUp;
                        // p.MouseMove += p_MouseMove;
                        this.Controls.Add(p);
                    }
            }
        }
    }
}
