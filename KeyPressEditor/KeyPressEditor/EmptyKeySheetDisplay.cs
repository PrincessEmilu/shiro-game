using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyPressEditor
{

    enum KeysAvailable
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public partial class EmptyKeySheetDisplay : Form
    {
        private int keyAmount;
        private List<Button> buttonsList;
        private List<Image> arrowImages;
        private List<Keys> keys;

        public EmptyKeySheetDisplay(int keyAmount)
        {
            this.keyAmount = keyAmount;

            keys = new List<Keys>(keyAmount);
            arrowImages = new List<Image>(5);


            arrowImages.Add(Properties.Resources.noneKey);
            arrowImages.Add(Properties.Resources.upArrow);
            arrowImages.Add(Properties.Resources.downArrrow);
            arrowImages.Add(Properties.Resources.leftArrow);
            arrowImages.Add(Properties.Resources.rightArrow);

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

            for (int i = 0; i < keyAmount; i++)
            {
                Button b = new Button();
                this.Controls.Add(b);
                b.Tag = 0;
                b.BackgroundImage = arrowImages[0];
                b.BackgroundImageLayout = ImageLayout.Stretch;
                b.Click += new EventHandler(button_Click);
                buttonsList.Add(b);
            }
        }

        //click on button.
        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int newTag = (int) b.Tag;
            if(newTag < 4)
            {
                newTag++;
            } else
            {
                newTag = 0;
            }
            b.Tag = newTag;
            b.BackgroundImage = arrowImages[newTag];
        }

        private void EmptyKeySheetDisplay_Load(object sender, EventArgs e)
        {
            generateMaping(keyAmount);
        }

        private void saveKeyPressesButton_Click(object sender, EventArgs e)
        {
            foreach(Button b in buttonsList)
            {
                int keyNum = (int)b.Tag;
                Keys keyAssigned = ReturnActualKey(keyNum);
                keys.Add(keyAssigned);
            }

            SaveToFile();
        }

        public Keys ReturnActualKey(int key)
        {
            Keys keyPress = Keys.None;
            switch(key)
            {
                case 1:
                    keyPress = Keys.Up;
                    break;
                case 2:
                    keyPress = Keys.Down;
                    break;
                case 3:
                    keyPress = Keys.Left;
                    break;
                case 4:
                    keyPress = Keys.Right;
                    break;
                default:
                    keyPress = Keys.None;
                    break;
            }
            return keyPress;
        }

        public void SaveToFile()
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Arrow_Key_Text_File_Shiro.txt";

            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)

            {

                StreamWriter writer = new StreamWriter(save.OpenFile());

                for(int i = 0; i < keys.Count; i++)

                {
                    if (i != keys.Count - 1)
                    {
                        writer.Write("Keys." + keys[i].ToString() + ",");
                    } else
                    {
                        writer.Write("Keys." + keys[i].ToString());
                    }

                }

                writer.Dispose();

                writer.Close();
            }
        }
    }
}
