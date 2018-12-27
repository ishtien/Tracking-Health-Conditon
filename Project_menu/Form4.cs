using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Project_menu
{
    
    
    
    public partial class Form4 : Form
    {
        Form2 lf = new Form2();
        public int check = 0;
        public Graphics gra;
        public Brush bush;
        public Graphics g;
        public int circle_loc = 6;
        public Point tmp;
        public Point draw_pt_s;
        public Point draw_pt_e;
        public int date = 5;
        public int index = 0;
        public float[,] weight = new float[5, 7];
        public float[,] fat = new float[5, 7];
        public string[,] body_picture = new string[5, 7];
        public string[,] dates = new string[5, 7];
        public float[] fbmi = new float[7];
        public int[] datanum = new int[5];
        public string line;
        public string line1;
        public string tmpline;
        public float height = 1.7f; //預設身高
        public int tmpindex = 0;
        public int food = DateTime.Today.Day % 14;
        public string context;
        PictureBox[] pic = new PictureBox[7];
        PictureBox[] bmi = new PictureBox[7];
        Label[] lab = new Label[7];
        StreamWriter sw;
        StreamReader sr;
        public int week = 0;
        public int count = 0;
        public int change = 0;
        public int saveweek = 0;
        public int temp = 0;
        public string pic_inform;
        public int music_check;
        public int music_idx;
        public string superstar_idx;
        public int scene_idx;
        public int lineno=0;

        //public int

        public int scheme_check;
        public int goal_weight; //預設目標體重
        string[] picpath = new string[7];
        string[] list = new string[10];

        public Form4()
        {
            InitializeComponent();
            string[] ItemName = new string[] { "彭于晏", "館長", "張鈞甯", "趙麗穎" };
            comboBox1.Items.AddRange(ItemName);

            pictureBox3.Visible = false;
            sr = new StreamReader("gym_goal.txt");
            string content;
            lineno = 0;
            while ((content = sr.ReadLine()) != null)
            {
                checkedListBox1.Items.Add(content);
                list[lineno] = content;
                lineno++;

            }
            sr.Close();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

        }
        public void renewdata()
        {
            count = 0;
            week = 0;
            for (int i = 0; i < 5; i++)
                datanum[i] = 0;
            op.Text = "";
            sr = new StreamReader("weight.txt");
            do
            {
                if (count == 7) //by a week
                {
                    week++;
                    count = 0;
                }
                line = sr.ReadLine();
                if (line == null) break;
                weight[week, count] = float.Parse(line);
                op.Text = line;
                datanum[week]++;
                count++;
                tmpindex = count;
            } while (true);
            sr.Close();

            count = 0;
            week = 0;
            op.Text = "";
            sr = new StreamReader("datecheck.txt");
            do
            {
                if (count == 7) //by a week
                {
                    week++;
                    count = 0;
                }
                line = sr.ReadLine();
                if (line == null) break;
                dates[week, count] = line;
                op.Text = line;
                count++;
            } while (true);
            sr.Close();


            count = 0;
            week = 0;
            sr = new StreamReader("picture.txt");
            do
            {
                if (count == 7) //by a week
                {
                    week++;
                    count = 0;
                }
                line = sr.ReadLine();
                if (line == null) break;
                body_picture[week, count] = line;
                op.Text = line;
                count++;
            } while (true);
            sr.Close();

            count = 0;
            week = 0;
            op.Text = "";
            sr = new StreamReader("fat.txt");
            do
            {
                if (count == 7) //by a week
                {
                    week++;
                    count = 0;
                }
                line = sr.ReadLine();
                if (line == null) break;
                fat[week, count] = float.Parse(line);
                op.Text = line;
                
                count++;
                
            } while (true);
            sr.Close();
        }
        private void tabPage5_Click(object sender, EventArgs e)
        {

        }
       
        private void Form4_Load(object sender, EventArgs e)
        {
            
            button4.BackColor = tabPage1.BackColor;
            button10.BackColor = tabPage1.BackColor;

            gra = this.tabPage1.CreateGraphics();
            
            //string[] ItemName = new string[] { "安海瑟威", "林志玲", "隋棠", "范冰冰" };
            //comboBox1.Items.AddRange(ItemName);
            sr = new StreamReader("musclestar.txt");
            superstar_idx = sr.ReadLine();
            sr.Close();

            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            //superstar_idx = @"superstar/" + superstar_idx;
            pictureBox4.Image = Image.FromFile(@"superstar/" + superstar_idx);

            sr = new StreamReader("music.txt");
            music_check = int.Parse(sr.ReadLine());
            sr.Close();
            button7_Click(null, null);
            sr = new StreamReader("scene.txt");
            scheme_check = int.Parse(sr.ReadLine());
            sr.Close();
            button6_Click(null, null);
            
            sr = new StreamReader("goal.txt");
            goal_weight = int.Parse(sr.ReadLine());
            sr.Close();
            
            lf.lf2 = this;
            //toolStripMenuItem2 = 選單ToolStripMenuItem;
            選單ToolStripMenuItem.MouseEnter += toolStripMenuItem19_MouseEnter;
            選單ToolStripMenuItem.MouseLeave += toolStripMenuItem20_MouseLeave_1;

            toolStripMenuItem1.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem1.MouseLeave += toolStripMenuItem20_MouseLeave_1;

            toolStripMenuItem2.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem3.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem4.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem5.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem6.MouseEnter += toolStripMenuItem19_MouseEnter;

            toolStripMenuItem2.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem3.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem4.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem5.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem6.MouseLeave += toolStripMenuItem20_MouseLeave_1;


            toolStripMenuItem2.Click += 體重BMIToolStripMenuItem_Click;
            toolStripMenuItem3.Click += 今日菜單ToolStripMenuItem_Click;
            toolStripMenuItem4.Click += 輸入當日體重ToolStripMenuItem_Click;
            toolStripMenuItem5.Click += 主題ToolStripMenuItem_Click;
            toolStripMenuItem6.Click += 目標ToolStripMenuItem_Click;
            toolStripMenuItem7.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem7.MouseLeave += toolStripMenuItem20_MouseLeave_1;

            toolStripMenuItem8.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem9.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem10.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem11.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem12.MouseEnter += toolStripMenuItem19_MouseEnter;

            toolStripMenuItem8.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem9.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem10.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem11.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem12.MouseLeave += toolStripMenuItem20_MouseLeave_1;

            toolStripMenuItem8.Click += 體重BMIToolStripMenuItem_Click;
            toolStripMenuItem9.Click += 今日菜單ToolStripMenuItem_Click;
            toolStripMenuItem10.Click += 輸入當日體重ToolStripMenuItem_Click;
            toolStripMenuItem11.Click += 主題ToolStripMenuItem_Click;
            toolStripMenuItem12.Click += 目標ToolStripMenuItem_Click;
            toolStripMenuItem13.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem13.MouseLeave += toolStripMenuItem20_MouseLeave_1;

            toolStripMenuItem14.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem15.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem16.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem17.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem18.MouseEnter += toolStripMenuItem19_MouseEnter;

            toolStripMenuItem14.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem15.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem16.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem17.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem18.MouseLeave += toolStripMenuItem20_MouseLeave_1;

            toolStripMenuItem14.Click += 體重BMIToolStripMenuItem_Click;
            toolStripMenuItem15.Click += 今日菜單ToolStripMenuItem_Click;
            toolStripMenuItem16.Click += 輸入當日體重ToolStripMenuItem_Click;
            toolStripMenuItem17.Click += 主題ToolStripMenuItem_Click;
            toolStripMenuItem18.Click += 目標ToolStripMenuItem_Click;

            toolStripMenuItem20.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem21.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem22.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem23.MouseEnter += toolStripMenuItem19_MouseEnter;
            toolStripMenuItem24.MouseEnter += toolStripMenuItem19_MouseEnter;

            toolStripMenuItem19.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem21.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem22.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem23.MouseLeave += toolStripMenuItem20_MouseLeave_1;
            toolStripMenuItem24.MouseLeave += toolStripMenuItem20_MouseLeave_1;

            toolStripMenuItem20.Click += 體重BMIToolStripMenuItem_Click;
            toolStripMenuItem21.Click += 今日菜單ToolStripMenuItem_Click;
            toolStripMenuItem22.Click += 輸入當日體重ToolStripMenuItem_Click;
            toolStripMenuItem23.Click += 主題ToolStripMenuItem_Click;
            toolStripMenuItem24.Click += 目標ToolStripMenuItem_Click;
            //menuStrip1_DragEnter+=menuStrip6_DragEnter;

            //string s =@"C:\Users\ish\Pictures\2.jpg";
            //System.IO.File.Move(s, @"D:\視窗程式\Project_menu_reop\Project_menu\bin\Debug\a.jpg");


            //read weight data
            renewdata();
            op.Text = week.ToString();
            op.Text += "  " + change.ToString();

            if (week == 0 || change == -(week))
                button10.Visible = false;
            else
                button10.Visible = true;

            if (week == 0 || change == week || week + change == week)
                button4.Visible = false;
            else
                button4.Visible = true;

            label14.Text = weight[week, tmpindex - 1].ToString();
            label15.Text = getbmi(weight[week, tmpindex - 1]).ToString();
            saveweek = week + 1;
            op.Text += "\n";
            if (change != 0)
            {
                week += change;
                index = 7;
            }
            else
                index = tmpindex;


            //set pic and location by weight data
            pic[0] = pic1; pic[1] = pic2; pic[2] = pic3; pic[3] = pic4; pic[4] = pic5; pic[5] = pic6; pic[6] = pic7;
            lab[0] = label1; lab[1] = label2; lab[2] = label3; lab[3] = label4; lab[4] = label5; lab[5] = label6; lab[6] = label7;
            bmi[0] = bmi1; bmi[1] = bmi2; bmi[2] = bmi3; bmi[3] = bmi4; bmi[4] = bmi5; bmi[5] = bmi6; bmi[6] = bmi7;
            for (int i = 0; i < index; i++)
            {
                tmp = new Point(pic[i].Location.X, (350 - 4 * (int)(weight[week, i])));
                pic[i].Location = tmp;
            }

            //label to show data
            
            for (int i = 0; i < 7; i++)
            {
                lab[i].Text = "";
            }
            colorlab1.Text = "";
            colorlab2.Text = "";
            for (int i = 0; i < 7; i++)
            {
                fbmi[i] = fat[week, i];
            }
            for (int i = 0; i < index; i++)
            {
                tmp = new Point(bmi[i].Location.X, (320 - 4 * (int)(fbmi[i])));
                bmi[i].Location = tmp;
            }
            
            tabPage2_Click(null, null);



            //目標的預設
            label16.Text = height.ToString();
            textBox2.Text = goal_weight.ToString();
            
        }
 



        public float getbmi(float w)
        {
            return w / (height * height);
        }
        /*
        public Form4()
        {
            InitializeComponent();
            string[] ItemName = new string[] { "安海瑟威", "林志玲", "隋棠", "范冰冰" };
            comboBox1.Items.AddRange(ItemName);

        }
        */
        private void tabPage1_Click(object sender, EventArgs e)
        {
            /*
            op.Text = "HERE";
            for (int i = 0; i < index; i++)
            {
                draw_weight(i);
            }
            for (int i = 0; i < index; i++)
            {
                draw_bmi(i);
            }
            wbinf();
            //gra = this.pic[0].CreateGraphics();
            //gra.DrawString("60", this.Font, Brushes.Black, 0, 10);
            */

        }
        public void wbinf()
        {
            gra = this.color1.CreateGraphics();
            bush = new SolidBrush(Color.Cyan);
            gra.FillEllipse(bush, 0, 0, 30, 30);
            colorlab1.Text = "體重 (kg)";
            gra = this.color2.CreateGraphics();
            bush = new SolidBrush(Color.Blue);
            gra.FillEllipse(bush, 0, 0, 30, 30);
            colorlab2.Text = "體脂率";

        }
        public void setlab()
        {
            for (int s = 0; s < datanum[week]; s++)
            {
                lab[s].Location = new Point(pic[s].Location.X-10, pic[s].Location.Y + 50);
                //lab[s].Text = (pic[s].Location.Y).ToString();


                if (s == datanum[week] - 1)
                {
                    if (change == 0)
                        lab[s].Text = "Today\n";
                }
                //lab[s].Text += (weight[s]).ToString()+"kg"+"\n";
                lab[s].Text += "\n" + " " + dates[week, s];

            }



        }
        public void draw_weight(int s)
        {


            if (s == 0)
            {
                gra = this.pic[s].CreateGraphics();
                bush = new SolidBrush(Color.Cyan);
                gra.FillEllipse(bush, 0, 0, 30, 30);
                gra.DrawString(("  "+weight[week, s]).ToString(), this.Font, Brushes.Black, 0, 10);
            }
            else
            {

                gra = this.pic[s].CreateGraphics();
                bush = new SolidBrush(Color.Cyan);
                gra.FillEllipse(bush, 0, 0, 30, 30);
                draw_pt_s = new Point(pic[s - 1].Location.X, 11 + pic[s - 1].Location.Y);
                draw_pt_e = new Point(5 + pic[s].Location.X, 12 + pic[s].Location.Y);
                gra = this.tabPage1.CreateGraphics();
                gra.DrawLine(new Pen(Color.Cyan, 1), draw_pt_s, draw_pt_e);
                gra = this.pic[s].CreateGraphics();
                gra.DrawString(("  "+weight[week, s]).ToString(), this.Font, Brushes.Black, 0, 10);

            }

        }
        public void draw_bmi(int s)
        {
            if (s == 0)
            {
                gra = this.bmi[s].CreateGraphics();
                bush = new SolidBrush(Color.Blue);
                gra.FillEllipse(bush, 0, 0, 30, 30);
                gra.DrawString("  "+(fat[week, s]).ToString(), this.Font, Brushes.White, 0, 10);
            }
            else
            {

                gra = this.bmi[s].CreateGraphics();
                bush = new SolidBrush(Color.Blue);
                gra.FillEllipse(bush, 0, 0, 30, 30);
                draw_pt_s = new Point(bmi[s - 1].Location.X, 11 + bmi[s - 1].Location.Y);
                draw_pt_e = new Point(5 + bmi[s].Location.X, 12 + bmi[s].Location.Y);
                gra = this.tabPage1.CreateGraphics();
                gra.DrawLine(new Pen(Color.Blue, 1), draw_pt_s, draw_pt_e);
                gra = this.bmi[s].CreateGraphics();
                gra.DrawString("  "+(fat[week, s]).ToString(), this.Font, Brushes.White, 0, 10);
            }
        }
        private int coo = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (coo == 0)
            {
                coo = 1;
                //for (int i = 0; i < index; i++)
                //    setlab(i);
                setlab();
            }
            else
            {
                coo = 0;
                for (int i = 0; i < 7; i++)
                {
                    lab[i].Text = "";
                }
            }

        }


        private void tabPage2_Click(object sender, EventArgs e)
        {
           /* pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Visible = true;
            pictureBox1.Image = Image.FromFile("food_time.png");
            if (food == 0)
                pictureBox2.Image = Image.FromFile("food_day1.png");
            else if (food == 1)
                pictureBox2.Image = Image.FromFile("food_day2.png");
            else if (food == 2)
                pictureBox2.Image = Image.FromFile("food_day3.png");
            else if (food == 3)
                pictureBox2.Image = Image.FromFile("food_day4.png");
            else if (food == 4)
                pictureBox2.Image = Image.FromFile("food_day5.png");
            else if (food == 5)
                pictureBox2.Image = Image.FromFile("food_day6.png");
            else if (food == 6)
                pictureBox2.Image = Image.FromFile("food_day7.png");
            else if (food == 7)
                pictureBox2.Image = Image.FromFile("food_day8.png");
            else if (food == 8)
                pictureBox2.Image = Image.FromFile("food_day9.png");
            else if (food == 9)
                pictureBox2.Image = Image.FromFile("food_day10.png");
            else if (food == 10)
                pictureBox2.Image = Image.FromFile("food_day11.png");
            else if (food == 11)
                pictureBox2.Image = Image.FromFile("food_day12.png");
            else if (food == 12)
                pictureBox2.Image = Image.FromFile("food_day13.png");
            else if (food == 13)
                pictureBox2.Image = Image.FromFile("food_day14.png");
*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            if (food == 0)
                pictureBox1.Image = Image.FromFile("foodinf_day1.png");
            else if (food == 1)
                pictureBox1.Image = Image.FromFile("foodinf_day2.png");
            else if (food == 2)
                pictureBox1.Image = Image.FromFile("foodinf_day3.png");
            else if (food == 3)
                pictureBox1.Image = Image.FromFile("foodinf_day4.png");
            else if (food == 4)
                pictureBox1.Image = Image.FromFile("foodinf_day5.png");
            else if (food == 5)
                pictureBox1.Image = Image.FromFile("foodinf_day6.png");
            else if (food == 6)
                pictureBox1.Image = Image.FromFile("foodinf_day7.png");
            else if (food == 7)
                pictureBox1.Image = Image.FromFile("foodinf_day8.png");
            else if (food == 8)
                pictureBox1.Image = Image.FromFile("foodinf_day9.png");
            else if (food == 9)
                pictureBox1.Image = Image.FromFile("foodinf_day10.png");
            else if (food == 10)
                pictureBox1.Image = Image.FromFile("foodinf_day11.png");
            else if (food == 11)
                pictureBox1.Image = Image.FromFile("foodinf_day12.png");
            else if (food == 12)
                pictureBox1.Image = Image.FromFile("foodinf_day13.png");
            else if (food == 13)
                pictureBox1.Image = Image.FromFile("foodinf_day14.png");
            //  food++;
            //  food %= 14;
        }

        private void tabPage2_MouseCaptureChanged(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox1.Image = Image.FromFile("food_time.png");
            if (food == 0)
                pictureBox2.Image = Image.FromFile("food_day1.png");
            else if (food == 1)
                pictureBox2.Image = Image.FromFile("food_day2.png");
            else if (food == 2)
                pictureBox2.Image = Image.FromFile("food_day3.png");
            else if (food == 3)
                pictureBox2.Image = Image.FromFile("food_day4.png");
            else if (food == 4)
                pictureBox2.Image = Image.FromFile("food_day5.png");
            else if (food == 5)
                pictureBox2.Image = Image.FromFile("food_day6.png");
            else if (food == 6)
                pictureBox2.Image = Image.FromFile("food_day7.png");
            else if (food == 7)
                pictureBox2.Image = Image.FromFile("food_day8.png");
            else if (food == 8)
                pictureBox2.Image = Image.FromFile("food_day9.png");
            else if (food == 9)
                pictureBox2.Image = Image.FromFile("food_day10.png");
            else if (food == 10)
                pictureBox2.Image = Image.FromFile("food_day11.png");
            else if (food == 11)
                pictureBox2.Image = Image.FromFile("food_day12.png");
            else if (food == 12)
                pictureBox2.Image = Image.FromFile("food_day13.png");
            else if (food == 13)
                pictureBox2.Image = Image.FromFile("food_day14.png");
        }

        private void color2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        public void getline()
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            sr = new StreamReader("datecheck.txt");
            line = null;
            while (true)
            {
                tmpline = sr.ReadLine();
                if (tmpline != null)
                    line = tmpline;
                else { break; }
            }
            if (line == null)  //first time use
            {
                sr.Close();
                sw = new StreamWriter("datecheck.txt");
                sw.WriteLine(DateTime.Now.Date.ToShortDateString());
                sw.Close();
                sw = new StreamWriter("weight.txt");
                sw.WriteLine(weightInput.Text);
                sw.Close();

                sw = new StreamWriter("fat.txt");
                sw.WriteLine(textBox1.Text);
                sw.Close();
                /*      sw = new StreamWriter("picture.txt");
                        sw.WriteLine(pic_inform);
                        sw.Close();
                        */
                todayw.Text = "已完成第一次資料輸入更新" + "\n" + DateTime.Now.Date.ToShortDateString();
            }

            else if (line == DateTime.Now.Date.ToShortDateString()) //modify today data
            {

                sw = new StreamWriter("weight.txt");

                for (int i = 0; i < saveweek; i++)
                {
                    if (i < saveweek - 1)
                        temp = datanum[i];
                    else temp = datanum[i] - 1;
                    for (int j = 0; j < temp; j++)
                    {
                        context = weight[i, j].ToString();
                        sw.WriteLine(context);
                    }
                }
                sw.WriteLine(weightInput.Text);
                sw.Close();

                sw = new StreamWriter("fat.txt");

                for (int i = 0; i < saveweek; i++)
                {
                    if (i < saveweek - 1)
                        temp = datanum[i];
                    else temp = datanum[i] - 1;
                    for (int j = 0; j < temp; j++)
                    {
                        context = fat[i, j].ToString();
                        sw.WriteLine(context);
                    }
                }
                sw.WriteLine(textBox1.Text);
                sw.Close();
                todayw.Text = "今日體重資料已更新" + "\n" + weightInput.Text;
                sw = new StreamWriter("picture.txt");

                for (int i = 0; i < saveweek; i++)
                {
                    if (i < saveweek - 1)
                        temp = datanum[i];
                    else temp = datanum[i] - 1;
                    for (int j = 0; j < temp; j++)
                    {
                        context = body_picture[i, j].ToString();
                        sw.WriteLine(context);
                    }
                }
                sw.WriteLine(pic_inform);
                sw.Close();
                todayw.Text += "今日圖片資料已更新" + "\n";
                Form4_Load(null, null);

            }
            else if (line != DateTime.Now.Date.ToShortDateString()) //new data and new date
            {
                sr.Close();
                sw = File.AppendText("datecheck.txt");   //renew date
                sw.WriteLine(DateTime.Now.Date.ToShortDateString());
                sw.Close();

                sw = File.AppendText("weight.txt");   //renew date
                sw.WriteLine(weightInput.Text);
                sw.Close();

                sw = File.AppendText("fat.txt");   //renew date
                sw.WriteLine(textBox1.Text);
                sw.Close();

                op.Text = pic_inform;
                sw = File.AppendText("picture.txt");   //renew date
                sw.WriteLine(pic_inform);
                sw.Close();
                todayw.Text = "今日體重資料已寫入" + "\n" + line + "\n" + DateTime.Now.Date.ToShortDateString();
            }
            else
                sr.Close();
            Form4_Load(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            change++;
            msec = 0;
            pictureBox3.Visible = true;
            timer1.Start();
            g.Clear(this.BackColor);
            gra.Clear(this.BackColor);
            for (int i = 0; i < 7; i++)
            {
                gra = this.bmi[i].CreateGraphics();
                gra.Clear(this.BackColor);
                g = this.pic[i].CreateGraphics();
                g.Clear(this.BackColor);

            }
            Form4_Load(null, null);
        }



        private void op_Click(object sender, EventArgs e)
        {

        }

        private void brouse_btn_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "JPEG|*.jpg|BMP|*.bmp|GIF|*.gif|PNG|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    body_pic.SizeMode = PictureBoxSizeMode.Zoom;

                    pic_inform = openFileDialog1.FileName;
                    op.Text = pic_inform;
                    body_pic.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("請選取適當格式的圖檔", "注意");
                }

            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            sw = new StreamWriter("music.txt");
            sw.WriteLine(music_check);
            sw.Close();
            SoundPlayer player2;
            if (music_check == 0)
            {
                player2 = new SoundPlayer(@"music/city of stars.wav");
                player2.PlayLooping();                         // 重複播放

            }
            else if (music_check == 1)
            {
                player2 = new SoundPlayer(@"music/yesterday.wav");
                player2.PlayLooping();　　　　　　　　                 // 重複播放
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            music_check = 0;

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            music_check = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sw = new StreamWriter("scene.txt");
            sw.WriteLine(scheme_check.ToString());
            sw.Close();
            if (scheme_check == 0)
            {
                Font f;
                f = new Font("Yu Mincho", 30, FontStyle.Bold);

                tabPage1.BackgroundImage = Image.FromFile("back/2.png");
                tabPage2.BackgroundImage = Image.FromFile("back/2.png");
                tabPage3.BackgroundImage = Image.FromFile("back/2.png");
                tabPage4.BackgroundImage = Image.FromFile("back/2.png");
                tabPage5.BackgroundImage = Image.FromFile("back/2.png");

                //tabPage1.BackColor = System.Drawing.Color.LightGreen;
                tabPage2.BackColor = System.Drawing.Color.LightGreen;
                tabPage3.BackColor = System.Drawing.Color.LightGreen;
                tabPage4.BackColor = System.Drawing.Color.LightGreen;
                tabPage5.BackColor = System.Drawing.Color.LightGreen;
                tabPage1.ForeColor = System.Drawing.Color.Black;
                tabPage2.ForeColor = System.Drawing.Color.Black;
                tabPage3.ForeColor = System.Drawing.Color.Black;
                tabPage4.ForeColor = System.Drawing.Color.Black;
                tabPage5.ForeColor = System.Drawing.Color.Black;

            }
            else if (scheme_check == 1)
            {
                //tabPage1.BackColor = System.Drawing.Color.LightGreen;
                tabPage2.BackColor = System.Drawing.Color.LightGreen;
                tabPage3.BackColor = System.Drawing.Color.LightGreen;
                tabPage4.BackColor = System.Drawing.Color.LightGreen;
                tabPage5.BackColor = System.Drawing.Color.LightGreen;
                tabPage1.ForeColor = System.Drawing.Color.Black;
                tabPage2.ForeColor = System.Drawing.Color.Black;
                tabPage3.ForeColor = System.Drawing.Color.Black;
                tabPage4.ForeColor = System.Drawing.Color.Black;
                tabPage5.ForeColor = System.Drawing.Color.Black;
                tabPage1.BackgroundImage = Image.FromFile("back/5.png");
                tabPage2.BackgroundImage = Image.FromFile("back/5.png");
                tabPage3.BackgroundImage = Image.FromFile("back/5.png");
                tabPage4.BackgroundImage = Image.FromFile("back/5.png");
                tabPage5.BackgroundImage = Image.FromFile("back/5.png");



            }
            else if (scheme_check == 2)
            {
               // tabPage1.BackColor = System.Drawing.Color.LightGreen;
                tabPage2.BackColor = System.Drawing.Color.LightGreen;
                tabPage3.BackColor = System.Drawing.Color.LightGreen;
                tabPage4.BackColor = System.Drawing.Color.LightGreen;
                tabPage5.BackColor = System.Drawing.Color.LightGreen;
                tabPage1.ForeColor = System.Drawing.Color.Orange;
                tabPage2.ForeColor = System.Drawing.Color.Black;
                tabPage3.ForeColor = System.Drawing.Color.Black;
                tabPage4.ForeColor = System.Drawing.Color.Black;
                tabPage5.ForeColor = System.Drawing.Color.Black;

                tabPage1.BackgroundImage = Image.FromFile("back/7.jpg");
                tabPage2.BackgroundImage = Image.FromFile("back/7.jpg");
                tabPage3.BackgroundImage = Image.FromFile("back/7.jpg");
                tabPage4.BackgroundImage = Image.FromFile("back/7.jpg");
                tabPage5.BackgroundImage = Image.FromFile("back/7.jpg");
            }
            else if (scheme_check == 3) {

                tabPage1.BackgroundImage = Image.FromFile("back/2.png");
                tabPage2.BackgroundImage = Image.FromFile("back/2.png");
                tabPage3.BackgroundImage = Image.FromFile("back/2.png");
                tabPage4.BackgroundImage = Image.FromFile("back/2.png");
                tabPage5.BackgroundImage = Image.FromFile("back/2.png");

                Font f;
                f = new Font("新細明體", 30, FontStyle.Bold);
               // tabPage1.BackColor = System.Drawing.Color.LightPink;
                tabPage2.BackColor = System.Drawing.Color.LightPink;
                tabPage3.BackColor = System.Drawing.Color.LightPink;
                tabPage4.BackColor = System.Drawing.Color.LightPink;
                tabPage5.BackColor = System.Drawing.Color.LightPink;
                tabPage1.ForeColor = System.Drawing.Color.Purple;
                tabPage2.ForeColor = System.Drawing.Color.Purple;
                tabPage3.ForeColor = System.Drawing.Color.Purple;
                tabPage4.ForeColor = System.Drawing.Color.Purple;
                tabPage5.ForeColor = System.Drawing.Color.Purple;
            }
            else if (scheme_check == 4) {
                tabPage1.BackgroundImage = Image.FromFile("back/5.png");
                tabPage2.BackgroundImage = Image.FromFile("back/5.png");
                tabPage3.BackgroundImage = Image.FromFile("back/5.png");
                tabPage4.BackgroundImage = Image.FromFile("back/5.png");
                tabPage5.BackgroundImage = Image.FromFile("back/5.png");

                Font f;
                f = new Font("新細明體", 30, FontStyle.Bold);
                //tabPage1.BackColor = System.Drawing.Color.LightPink;
                tabPage2.BackColor = System.Drawing.Color.LightPink;
                tabPage3.BackColor = System.Drawing.Color.LightPink;
                tabPage4.BackColor = System.Drawing.Color.LightPink;
                tabPage5.BackColor = System.Drawing.Color.LightPink;
                tabPage1.ForeColor = System.Drawing.Color.Purple;
                tabPage2.ForeColor = System.Drawing.Color.Purple;
                tabPage3.ForeColor = System.Drawing.Color.Purple;
                tabPage4.ForeColor = System.Drawing.Color.Purple;
                tabPage5.ForeColor = System.Drawing.Color.Purple;
            }
            else if (scheme_check == 5) {
                tabPage1.BackgroundImage = Image.FromFile("back/7.jpg");
                tabPage2.BackgroundImage = Image.FromFile("back/7.jpg");
                tabPage3.BackgroundImage = Image.FromFile("back/7.jpg");
                tabPage4.BackgroundImage = Image.FromFile("back/7.jpg");
                tabPage5.BackgroundImage = Image.FromFile("back/7.jpg");

                Font f;
                f = new Font("新細明體", 30, FontStyle.Bold);
                //tabPage1.BackColor = System.Drawing.Color.LightPink;
                tabPage2.BackColor = System.Drawing.Color.LightPink;
                tabPage3.BackColor = System.Drawing.Color.LightPink;
                tabPage4.BackColor = System.Drawing.Color.LightPink;
                tabPage5.BackColor = System.Drawing.Color.LightPink;
                tabPage1.ForeColor = System.Drawing.Color.Orange;
                tabPage2.ForeColor = System.Drawing.Color.Purple;
                tabPage3.ForeColor = System.Drawing.Color.Purple;
                tabPage4.ForeColor = System.Drawing.Color.Purple;
                tabPage5.ForeColor = System.Drawing.Color.Purple;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (scheme_check == 3)
            {
                scheme_check = 0;
            }
            else if (scheme_check == 4)
            {
                scheme_check = 1;
            }
            else if (scheme_check == 5)
            {
                scheme_check = 2;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
            if (scheme_check == 0)
            {
                scheme_check = 3;
            }
            else if (scheme_check == 1)
            {
                scheme_check = 4;
            }
            else if (scheme_check == 2)
            {
                scheme_check = 5;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (scheme_check == 3)
            {
                scheme_check = 0;
            }
            else if (scheme_check == 4)
            {
                scheme_check = 1;
            }
            else if (scheme_check == 5)
            {
                scheme_check = 2;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            string tmp = (comboBox1.SelectedIndex + 5) + ".jpg";
            //superstar_idx = @"superstar/" + superstar_idx;
            pictureBox4.Image = Image.FromFile(@"superstar/" + tmp);
            sw = new StreamWriter("musclestar.txt");
            sw.WriteLine(tmp);
            sw.Close();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sw = new StreamWriter("goal.txt");
            sw.WriteLine(textBox2.Text);
            sw.Close();
            /*
            sw = new StreamWriter("superstar.txt");
            sw.WriteLine();
            sw.Close();
            */
        }

        private void button8_Click(object sender, EventArgs e)
        {

            fontDialog1.ShowColor = true;
            fontDialog1.ShowDialog();
            tabPage1.Font = fontDialog1.Font;
            tabPage1.ForeColor = fontDialog1.Color;
            tabPage2.Font = fontDialog1.Font;
            tabPage2.ForeColor = fontDialog1.Color;
            tadpage2.Font = fontDialog1.Font;
            tadpage2.ForeColor = fontDialog1.Color;
            tabPage4.Font = fontDialog1.Font;
            tabPage4.ForeColor = fontDialog1.Color;
            tabPage5.Font = fontDialog1.Font;
            tabPage5.ForeColor = fontDialog1.Color;
        }
        public int check_days = 1000000;
        private void showbody_Click(object sender, EventArgs e)
        {

            int cc = 7;
            if (check_days == 1000000)
            {
                check_days = index;
                po.Text = "ha" + index;
                //button10.Visible = false;
            }

            if (button4.Visible == false)
            {
                cc = check_days;
            }
            po.Text = cc.ToString();
            for (int i = 0; i < cc; i++)
            {
                picpath[i] = body_picture[week, i];
                op.Text = picpath[i];
            }
            if (cc != 7)
            {
                for (int i = cc + 1; i < 7; i++)
                {
                    picpath[i] = null;
                }
            }
            lf.showpic(picpath[0], picpath[1], picpath[2], picpath[3], picpath[4], picpath[5], picpath[6]);
            lf.showing("haha");
            lf.Show();
            for (int i = 0; i < 7; i++)
                picpath[i] = null;
            //Form4_Load(null, null);

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 體重BMIToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 0;
        }

        private void 今日菜單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void 主題ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void 目標ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void menuStrip6_DragEnter(object sender, DragEventArgs e)
        {
            //toolStripMenuItem19.ShowDropDown();
        }

        private void toolStripMenuItem19_MouseLeave(object sender, EventArgs e)
        {
            //toolStripMenuItem19.HideDropDown();
        }

        private void toolStripMenuItem19_MouseMove(object sender, MouseEventArgs e)
        {
            //toolStripMenuItem19.ShowDropDown();
        }

        private void toolStripMenuItem19_MouseHover(object sender, EventArgs e)
        {

        }

        private void 輸入當日體重ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            goal_weight = int.Parse(textBox2.Text);
            sw = new StreamWriter("goal.txt");
            sw.WriteLine(goal_weight);
            sw.Close();
        }

        private void toolStripMenuItem19_MouseEnter(object sender, EventArgs e)
        {
            toolStripMenuItem19.ShowDropDown();
            disap = 0;
        }

        private void toolStripMenuItem20_MouseEnter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem20_MouseLeave(object sender, EventArgs e)
        {
            //toolStripMenuItem19.HideDropDown();
            //disap = 1;
            //timer1.Start();
        }

        private void toolStripMenuItem21_MouseEnter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem21_MouseLeave(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem22_MouseEnter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem22_MouseLeave(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip6_MouseLeave(object sender, EventArgs e)
        {
            //toolStripMenuItem19.HideDropDown();

        }
        public int msec = 0;
        public int disap = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void weightInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {
            op.Text = "HERE";
            for (int i = 0; i < index; i++)
            {
                draw_weight(i);
            }
            for (int i = 0; i < index; i++)
            {
                draw_bmi(i);
            }
            wbinf();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            string tmp = (comboBox1.SelectedIndex + 5) + ".jpg";
            op.Text = tmp;
            //superstar_idx = @"superstar/" + superstar_idx;
            pictureBox4.Image = Image.FromFile(@"superstar/" + tmp);
            sw = new StreamWriter("musclestar.txt");
            sw.WriteLine(tmp);
            sw.Close();
        }

        private void toolStripMenuItem20_MouseLeave_1(object sender, EventArgs e)
        {
            disap = 1;
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            msec++;
            if (msec >= 6)
            {
                if (disap == 1)
                {
                    toolStripMenuItem19.HideDropDown();
                }
                pictureBox3.Visible = false;
                disap = 0;
                timer1.Stop();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (scheme_check == 1)
            {
                scheme_check = 0;
            }
            else if (scheme_check == 2)
            {
                scheme_check = 0;
            }
            else if (scheme_check == 4)
            {
                scheme_check = 3;
            }
            else if (scheme_check == 5)
            {
                scheme_check = 3;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (scheme_check == 0)
            {
                scheme_check = 1;
            }
            else if (scheme_check == 2)
            {
                scheme_check = 1;
            }
            else if (scheme_check == 3)
            {
                scheme_check = 4;
            }
            else if (scheme_check == 5)
            {
                scheme_check = 4;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (scheme_check == 0)
            {
                scheme_check = 2;
            }
            else if (scheme_check == 1)
            {
                scheme_check = 2;
            }
            else if (scheme_check == 3)
            {
                scheme_check = 5;
            }
            else if (scheme_check == 4)
            {
                scheme_check = 5;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            change--;
            msec = 0;
            pictureBox3.Visible = true;
            timer1.Start();
            gra.Clear(this.BackColor);
            //g.Clear(this.BackColor);
            
            for (int i = 0; i < 7; i++)
            {
                gra = this.bmi[i].CreateGraphics();
                gra.Clear(this.BackColor);
                g = this.pic[i].CreateGraphics();
                g.Clear(this.BackColor);

            }
            Form4_Load(null, null);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            sw = new StreamWriter("gym_goal.txt");
            sw.WriteLine(textBox4.Text);
            sw.Close();


            checkedListBox1.Items.Clear();
            sr = new StreamReader("gym_goal.txt");
            string content;
            lineno = 0;
            while ((content = sr.ReadLine()) != null)
            {
                checkedListBox1.Items.Add(content);
                list[lineno] = content;
                lineno++;

            }
            sr.Close();

            textBox4.Text = "";


        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            int finish=1;
            int yes = 0;
            for (int i = 0; i < lineno; i++) {
                if (checkedListBox1.GetItemChecked(i) == false)
                {
                    textBox3.Text += list[i];
                    textBox3.Text += "\n\r\n";
                    finish = 0;
                }
                else yes++;
            }

            if (finish == 1)
            {
                textBox3.Text = "恭喜你！完成了！";
            }
            else {
                textBox3.Text += "\n繼續加油！";
                textBox3.Text += "\n\r\n達成率:" + ((float)yes / lineno).ToString();
            }

        }
    }
}
