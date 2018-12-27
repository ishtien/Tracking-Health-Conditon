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
    public partial class Form2 : Form
    {
        public Form4 lf2 = null;
        public Form1 lf=null;
        public void showing(string a)
        {
            label1.Text = a;
        }
        public void showpic(string s1, string s2, string s3, string s4, string s5, string s6, string s7)
        {
            if (s1 != null)
            {
                pictureBox1.Visible = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(s1);
            }
            else {
                pictureBox1.Visible = false;
            }
            if (s2 != null)
            {
                pictureBox2.Visible = true;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = Image.FromFile(s2);
            }
            else {
                pictureBox2.Visible = false;
            }

            if (s3 != null)
            {
                pictureBox3.Visible = true;
                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox3.Image = Image.FromFile(s3);
            }
            else {
                pictureBox3.Visible = false;
            }

            if (s4 != null)
            {
                pictureBox4.Visible = true;
                pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox4.Image = Image.FromFile(s4);
            }
            else {
                pictureBox4.Visible = false;
            }

            if (s5 != null)
            {
                pictureBox5.Visible = true;
                pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox5.Image = Image.FromFile(s5);
            }
            else
            {
                pictureBox5.Visible = false;
            }

            if (s6 != null)
            {
                pictureBox6.Visible = true;
                pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox6.Image = Image.FromFile(s6);
            }
            else
            {
                pictureBox6.Visible = false;
            }

            if (s7 != null)
            {
                pictureBox7.Visible = true;
                pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox7.Image = Image.FromFile(s7);
            }
            else
            {
                pictureBox7.Visible = false;
            }
        }

        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
