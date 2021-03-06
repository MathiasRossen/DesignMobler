﻿using System;
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
    public partial class MainWindow : Form
    {

        private Order order;
        private IBoardRepository br;

        public MainWindow()
        {
            InitializeComponent();

            order = new Order();
            br = new BoardRepositoryFile(@"C:\varenr");

            ddSurface.DataSource = Enum.GetValues(typeof(Surfaces));

            ddExtension.Items.Insert(0, "Ja");
            ddExtension.Items.Insert(1, "Nej");
            ddExtension.SelectedIndex = 0;

            LoadBoard();
        }

        private void LoadBoard()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 1;

            foreach (Board board in order.GetBoards())
            {
                DisplayBoardInfo(board);
            }
        }

        private void DisplayBoardInfo(Board board)
        {
            string extension;
            if (board.Extension)
                extension = "Ja";
            else
                extension = "Nej";

            tableLayoutPanel1.RowCount += 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(new Label() { Text = board.WareId.ToString() }, 0, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(new Label() { Text = board.Length.ToString() }, 1, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(new Label() { Text = board.Width.ToString() }, 2, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(new Label() { Text = extension }, 3, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(new Label() { Text = board.Surface.ToString() }, 4, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(new Label() { Text = board.Quantity.ToString() }, 5, tableLayoutPanel1.RowCount - 1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int warenumber;
            if (int.TryParse(txtWareNumber.Text, out warenumber))
            {
                Board boardtoload = new Board(warenumber, br);
                txtLength.Text = boardtoload.Length.ToString();
                txtWidth.Text = boardtoload.Width.ToString();

                if (boardtoload.Extension)
                {
                    ddExtension.SelectedIndex = 0;
                }
                else
                {
                    ddExtension.SelectedIndex = 1;

                }

                ddSurface.SelectedIndex = Convert.ToInt32(boardtoload.Surface);


            }
            else if (!string.IsNullOrWhiteSpace(txtWareNumber.Text))
            {
                txtWareNumber.Text = "";
                MessageBox.Show("Vare nummer er ikke et tal.", "Fejl", MessageBoxButtons.OK);


            }

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
            int count;
            bool extension;
            Surfaces surface;

            if (int.TryParse(txtWareNumber.Text, out warenumber) && !string.IsNullOrWhiteSpace(txtWareNumber.Text))
            {
                if (int.TryParse(txtLength.Text, out length) && !string.IsNullOrWhiteSpace(txtLength.Text))
                {
                    if (int.TryParse(txtWidth.Text, out width) && !string.IsNullOrWhiteSpace(txtWidth.Text))
                    {
                        if (int.TryParse(Count.Text, out count) && !string.IsNullOrWhiteSpace(Count.Text))
                        {
                            if (Convert.ToInt32(ddExtension.SelectedIndex) == 0)
                            {
                                extension = true;
                            }
                            else
                            {
                                extension = false;
                            }

                            surface = (Surfaces)Enum.Parse(typeof(Surfaces), ddSurface.SelectedValue.ToString());
                            Board newboard = new Board(warenumber, br);
                            newboard.Width = width;
                            newboard.Length = length;
                            newboard.Extension = extension;
                            newboard.Surface = surface;
                            newboard.Quantity = count;
                            order.AddBoard(newboard, br);
                            MessageBox.Show("Varenr: " + warenumber.ToString() + " er nu blevet tilføjet.");

                            LoadBoard();
                        }
                        else
                        {
                            MessageBox.Show("Antal er ikke angivet korrekt.", "Fejl", MessageBoxButtons.OK);

                        }

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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlateCalculator calc = new PlateCalculator(order);
            calc.CalculateBoards();
            ExcelCreator excel = new ExcelCreator(calc.Plates, @"C:\Users\casp4\Documents");
            excel.CreateExcel();



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int warenr;
            if (int.TryParse(txtDeleteWareNumber.Text, out warenr) && !string.IsNullOrWhiteSpace(txtDeleteWareNumber.Text))
            {
                
                var confirmResult = MessageBox.Show("Er du sikker på du vil slette order nr:" + warenr + "??",
                                     "Bekræft slettelse",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    order.RemoveBoard(warenr);
                    LoadBoard();
                }
                else
                {
                   
                }
                
            }
            else
            {
                MessageBox.Show("Varenummer er ikke angivet korrekt.", "Fejl", MessageBoxButtons.OK);
            }

        }
    }
}
