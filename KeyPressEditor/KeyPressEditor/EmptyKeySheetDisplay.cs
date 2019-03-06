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
    public partial class EmptyKeySheetDisplay : Form
    {
        private int keyAmount;
        private List<Button> buttonsList;
        public EmptyKeySheetDisplay(int keyAmount)
        {
            this.keyAmount = keyAmount;
            InitializeComponent();
            buttonsList = new List<Button>(keyAmount);
            keysLayout.AutoSize = true;
            generateButtonList();
        }

        public bool isEven(int amt)
        {
            bool isEven = false;
            if (amt % 2 == 0)
            {
                isEven = true;
            }
            return isEven;
        }

        //add buttons to the layout panel.
        public void generateMaping(int amt)
        {

            foreach(Button b in buttonsList)
            {
                keysLayout.Controls.Add(b);
            }
        }

        //generate a list of buttons based on how many the user set.
        public void generateButtonList()
        {
            for(int i = 0; i < keyAmount; i++)
            {
                Button b = new Button();
                this.Controls.Add(b);
                b.Click += new EventHandler(button_Click);
                buttonsList.Add(b);
            }
        }

        //click on button.
        private void button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello, I work!");
        }

        private void EmptyKeySheetDisplay_Load(object sender, EventArgs e)
        {
            generateMaping(keyAmount);
        }

        private void saveKeyPressesButton_Click(object sender, EventArgs e)
        {
            //do something!
        }
    }
}
