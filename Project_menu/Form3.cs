using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_menu
{
    public partial class Form3 : Form
    {
        Form1 lf = new Form1();


        Form4 lf1 = new Form4();
        public Form3()
        {
            InitializeComponent();
            label7.Text = "";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0000")
            {
                this.Text = "選擇模式";
                tabControl1.SelectedIndex = 2;
            }
            else
                label7.Text = "QQ 打錯了";

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lf.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lf1.Show();
            this.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            tabPage1.BackgroundImage = Image.FromFile("bg.jpg");
            tabPage3.BackgroundImage = Image.FromFile("bg.jpg");

        }
    }
}
