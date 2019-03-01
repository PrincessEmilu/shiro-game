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
    public partial class Form1 : Form
    {
        int tileCounter = 1;
        int paddingNum = 0;
        int backgroundTile = 1;
        int sizeOfTiles = 100;
        public Form1()
        {
            InitializeComponent();
        }

        private void loadPNGFile_Click(object sender, EventArgs e)
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

        private void previewMapButton_Click(object sender, EventArgs e)
        {
            MapPreviewer map = new MapPreviewer(tileBoxPreview.Image, tileCounter, paddingNum, backgroundTile, sizeOfTiles);
            map.ShowDialog();
        }

        private void howManyTileCounter_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown howManyTiles = (NumericUpDown) sender;
            tileCounter = (int) howManyTiles.Value;
        }

        private void paddingNumberInput_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown paddingNumeric = (NumericUpDown)sender;
            paddingNum = (int)paddingNumeric.Value;
        }

        private void backgroundTileSelection_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown backgroundTileSelection = (NumericUpDown)sender;
            backgroundTile = (int)backgroundTileSelection.Value;
        }

        private void sizeOfTilesDropdown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown sizeOfTilesSelection = (NumericUpDown)sender;
            sizeOfTiles = (int)sizeOfTilesSelection.Value;
        }
    }
}
