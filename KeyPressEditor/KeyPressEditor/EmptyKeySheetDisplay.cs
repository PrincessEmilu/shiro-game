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
        public EmptyKeySheetDisplay(int keyAmount)
        {
            this.keyAmount = keyAmount;
            InitializeComponent();
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

        public void generateMaping(int amt)
        {
            int rows = determineRows(amt);
            int columns = determineCol(amt, rows);

            int buttonSize = 50;
            int Distance = 20;
            int start_x = 10;
            int start_y = 10;

            for (int x = 0; x < columns; x++)
                {
                    for (int y = 0; y < rows; y++)
                    {
                    Button tmpButton = new Button();
                    tmpButton.Top = start_x + (x * buttonSize + Distance);
                    tmpButton.Left = start_y + (y * buttonSize + Distance);
                    tmpButton.Width = buttonSize;
                    tmpButton.Height = buttonSize;
                    tmpButton.FlatAppearance.BorderSize = 0;
                    this.Controls.Add(tmpButton);
                    tmpButton.Click += new EventHandler(button_Click);
                }
            }
        }


        public int determineCol(int amt, int rows)
        {
            int col = 0;

            if (checkIfPrime(amt))
            {
                col = 1;
            } else
            {
                col = amt / rows;
            }

            return col;
        }

        public int determineRows(int amt)
        {
            int rows = 0;

            if (isEven(amt))
            {
                if (amt % 8 == 0)
                {
                    rows = amt / 8;
                }

                if (amt % 6 == 0)
                {
                    rows = amt / 6;
                }

                if (amt % 4 == 0)
                {
                    rows = amt / 4;
                }
                if (amt % 5 == 0)
                {
                    rows = amt / 5;
                }

            } else
            {
                if (amt % 5 == 0)
                {
                    rows = amt / 5;
                }

                if (amt % 7 == 0)
                {
                    rows = amt / 7;
                }

                if (amt % 3 == 0)
                {
                    rows = amt / 3;
                }
            }

            if (checkIfPrime(amt))
            {
                rows = amt;
            }

            return rows;
        }

        public bool checkIfPrime(int amt)
        {
            int count = 0;
            bool isPrime = true;

            for (int i = 2; i < amt; i++)
            {
                if (amt % i == 0)
                    count++;
            }

            if (count > 1)
            {
                isPrime = false;
            }

            return isPrime;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello, I work!");
        }

        private void EmptyKeySheetDisplay_Load(object sender, EventArgs e)
        {
            generateMaping(keyAmount);
        }
    }
}
