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
    public partial class mainEditor : Form
    {
        //Fields
        Random rng = new Random();

        int tileWidth;
        int tileHeight;

        int tilesPerScreenWidth;
        int tilesPerScreenHeight;

        int screensHorizontal;
        int screensVertical;

        int gridPanelWidth;
        int gridPanelHeight;

        Panel[,] buttons;

        public mainEditor()
        {
            InitializeComponent();
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
        public void GenerateMap()
        {
            //Sets values
            /*
            tileWidth = 50;
            tileHeight = tileWidth;

            tilesPerScreenWidth = 16;
            tilesPerScreenHeight = 9;

            screensHorizontal = 2;
            screensVertical = 2;

            gridPanelWidth = tilesPerScreenWidth * screensHorizontal;
            gridPanelHeight = tilesPerScreenHeight * screensVertical;
            */

            //Generate that map

            /*
            buttons = new Panel[gridPanelWidth, gridPanelHeight];

            for(int j = 0; j < gridPanelHeight; j ++)
            {
                for(int i = 0; i < gridPanelWidth; i ++)
                {
                    buttons[i, j] = new Panel();
                    buttons[i, j].Location = new Point(i * tileWidth, j * tileHeight + toolbarMain.Height);
                    buttons[i, j].Size = new Size(tileWidth, tileHeight);
                    buttons[i, j].BackColor = Color.FromArgb(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));

                    Controls.Add(buttons[i, j]);
                }
            }

            Console.WriteLine("Done");
            */
        }
    }
}
