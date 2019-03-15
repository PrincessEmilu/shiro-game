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
    public partial class ErrorMessage : Form
    {
        public ErrorMessage(string message)
        {
            InitializeComponent();

            labelErrorDetails.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelErrorDetails_Click(object sender, EventArgs e)
        {

        }

        private void SaveError_Load(object sender, EventArgs e)
        {

        }
    }
}
