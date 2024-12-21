using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        int nr = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_click(object sender, EventArgs e)
        {
            nr++;
            Button b = (Button)sender;
            if (nr%2!=0)
            {
                b.Text = "X";

            }
            else
            {
                b.Text = "O";

            }
            b.Enabled = false;


            if (
                (b1.Text == b2.Text && b2.Text == b3.Text && b1.Enabled== false) ||
                (b4.Text == b5.Text && b5.Text == b6.Text && b4.Enabled == false) ||
                (b7.Text == b8.Text && b8.Text == b9.Text && b7.Enabled == false) ||
                (b1.Text == b4.Text && b4.Text == b7.Text && b1.Enabled == false) ||
                (b2.Text == b5.Text && b5.Text == b8.Text && b2.Enabled == false) ||
                (b3.Text == b6.Text && b6.Text == b9.Text && b3.Enabled == false) ||
                (b1.Text == b5.Text && b5.Text == b9.Text && b1.Enabled == false) ||
                (b3.Text == b5.Text && b5.Text == b7.Text && b3.Enabled == false)
                )
            {
                if (nr%2!=0)
                {
                    MessageBox.Show("X Kazandı");

                }
                else  
                {
                    MessageBox.Show("O Kazandı");
                }
                Application.Exit();
                
            }
            else if (nr==9)
            {
                MessageBox.Show("Kazanan Yok !");
                Application.Exit();
            }
        }
    }
}
