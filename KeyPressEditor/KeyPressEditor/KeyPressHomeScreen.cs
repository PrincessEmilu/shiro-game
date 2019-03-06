using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyPressEditor
{
    public partial class KeyPressHomeScreen : Form
    {
        private int howManyKeys = 1;
        public KeyPressHomeScreen()
        {
            InitializeComponent();
        }

        private void generateKeySheetButton_Click(object sender, EventArgs e)
        {
            EmptyKeySheetDisplay keyDisplay = new EmptyKeySheetDisplay(howManyKeys);
            keyDisplay.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown howManyKeysObj = (NumericUpDown)sender;
            howManyKeys = (int)howManyKeysObj.Value;
        }
    }
}
