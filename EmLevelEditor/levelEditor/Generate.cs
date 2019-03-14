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
    public partial class Generate : Form
    {
        //Fields
        //Reference to editor
        mainEditor mapEditor;

        int tileWidth = 32;
        int tileHeight = 32;
        int tilesInImage = 1;
        int tilesPerScreenWidth = 1;
        int tilesPerScreenHeight = 1;
        int screensHorizontal = 1;
        int screensVertical = 1;

        

        public Generate(mainEditor mapEditor)
        {
            this.mapEditor = mapEditor;
            InitializeComponent();
        }

        private void Generate_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Generates the map
            mapEditor.GenerateMap(tileBoxPreview.Image, tilesInImage, tileWidth, tileHeight, tilesPerScreenWidth, tilesPerScreenHeight, screensHorizontal, screensVertical);

            this.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void buttonLoadPNG_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "png files (*.png)|*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tileBoxPreview.Image = Image.FromFile(dlg.FileName);
            }
            dlg.Dispose();
        }

        //These are the value changes for each numericUpDown
        private void numericTileSize_ValueChanged(object sender, EventArgs e)
        {
            tileWidth = (int)((NumericUpDown)sender).Value;
            tileHeight = tileWidth;
        }

        private void numericTilesInImage_ValueChanged(object sender, EventArgs e)
        {
            tilesInImage = (int)((NumericUpDown)sender).Value;
        }

        private void numericTilesPerRow_ValueChanged(object sender, EventArgs e)
        {
            tilesPerScreenWidth = (int)((NumericUpDown)sender).Value;
        }

        private void numericTilesPerColumn_ValueChanged(object sender, EventArgs e)
        {
            tilesPerScreenHeight = (int)((NumericUpDown)sender).Value;
        }

        private void numericScreensPerRow_ValueChanged(object sender, EventArgs e)
        {
            screensHorizontal = (int)((NumericUpDown)sender).Value;
        }

        private void numericScreensPerColumn_ValueChanged(object sender, EventArgs e)
        {
            screensVertical = (int)((NumericUpDown)sender).Value;
        }
    }
}
