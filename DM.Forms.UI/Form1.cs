using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DM.Core;

namespace DM.Forms.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int warenumber;
            int length;
            int width;

            // hejsa
            if (int.TryParse(txtWareNumber.Text, out warenumber) || !string.IsNullOrWhiteSpace(txtWareNumber.Text))
            {
                if (int.TryParse(txtLength.Text, out length) || !string.IsNullOrWhiteSpace(txtLength.Text))
                {
                    if (int.TryParse(txtWidth.Text, out width) || !string.IsNullOrWhiteSpace(txtWidth.Text))
                    {
                        //new Board(warenumber, length, width);
                    }
                    else
                    {
                        MessageBox.Show("Bredden er ikke angivet korrekt.", "Fejl", MessageBoxButtons.OK);

                    }
                }
                else
                {
                    MessageBox.Show("Længden er ikke angivet korrekt.", "Fejl", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vare nummer er ikke angivet korrekt.", "Fejl", MessageBoxButtons.OK);
            }

        }
    }
}
