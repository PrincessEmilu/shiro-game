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
        mainEditor mapEditor;
        public Generate(mainEditor mapEditor)
        {
            InitializeComponent();
        }

        private void Generate_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: ADD ARGUMENTS
            mapEditor.GenerateMap();
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
    }
}
