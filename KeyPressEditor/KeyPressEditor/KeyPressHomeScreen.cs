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
        //set the default min of keys to be one.
        private int howManyKeys = 1;
        
        //constructor
        public KeyPressHomeScreen()
        {
            InitializeComponent();
        }

        //generate the new window based on what the user set.
        private void generateKeySheetButton_Click(object sender, EventArgs e)
        {
            EmptyKeySheetDisplay keyDisplay = new EmptyKeySheetDisplay(howManyKeys);
            keyDisplay.ShowDialog();
        }

        //save the value of the numeric up and down (limit 1-400 nums)
        //to the how many keys variable
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown howManyKeysObj = (NumericUpDown)sender;
            howManyKeys = (int)howManyKeysObj.Value;
        }
    }
}
