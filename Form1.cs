using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 抽籤
{
    public partial class Form1 : Form
    {
        int[] randon = new int[31] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
        int[] teacher = new int[4] { 1, 2, 3, 4 };
        int[] staff = new int[3] { 1, 8, 16 };
        int count = 0;
        int countThree = 0;
        int countStaff = 0;

        public Form1()
        {
            InitializeComponent();
            //int[] randon = new int[31];

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            try
            { System.Media.SoundPlayer backgroundMusic = new System.Media.SoundPlayer(@"D:\商務謝師夜\抽籤背景音樂.wav");
              backgroundMusic.PlayLooping();
            }
            catch
            {
                MessageBox.Show("確認音效位址");
            }

            seatNo.Visible = false;
            groupNo.Visible = false;
            button2.Visible = false;

            Thread thread = new Thread(new ThreadStart(ColorChange));
            thread.Start();


            Random rnd = new Random(); //產生亂數初始值
            Random rdThree = new Random();
            Random rdStaff = new Random();

            for (int i = 0; i < randon.Length; i++)
            {
                int randomIndex = rnd.Next(randon.Length);
                int tempIndex = randon[randomIndex];
                randon[randomIndex] = randon[i];
                randon[i] = tempIndex;
            }

            for (int j = 0; j<teacher.Length; j++)
            {
                int threeIndex = rdThree.Next(teacher.Length);
                int tmpThreeIndex = teacher[threeIndex];
                teacher[threeIndex] = teacher[j];
                teacher[j] = tmpThreeIndex;
            }

            for (int z = 0; z < staff.Length; z++)
            {
                int staffIndex = rdThree.Next(staff.Length);
                int tmpStaffIndex = staff[staffIndex];
                staff[staffIndex] = staff[z];
                staff[z] = tmpStaffIndex;
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer startMusic = new System.Media.SoundPlayer(@"D:\商務謝師夜\開始抽籤.wav");
                startMusic.Play();
            }
            catch
            {
                MessageBox.Show("確認音效位址");
            }

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            seatNo.Visible = true;
            groupNo.Visible = true;
            button2.Visible = true;
            button1.Visible = false;

            Thread thread1 = new Thread(new ThreadStart(ColorChange));
            thread1.Start();
            thread1.Abort();


            try
            {
                int seat = randon[count];

                if(seat == 1 || seat == 9 || seat == 17)
                {
                    count++;
                    seat = randon[count];
                }
                seatNo.Text = "座位號碼：" +seat.ToString();
                count++;

                if (seat <= 8)
                {
                    groupNo.Text = "分組組別：A";
                }
                else if (seat <= 16)
                {
                    groupNo.Text = "分組組別：B";
                }
                else if (seat <= 24)
                {
                    groupNo.Text = "分組組別：C";
                }
                else
                {
                    groupNo.Text = "分組組別：D";
                }
            }
            catch
            {
                MessageBox.Show("全員到齊！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer backgroundMusic = new System.Media.SoundPlayer(@"D:\商務謝師夜\抽籤背景音樂.wav");
                backgroundMusic.PlayLooping();
            }
            catch
            {
                MessageBox.Show("確認音效位址");
            }

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            button1.Visible = true;
            seatNo.Visible = false;
            groupNo.Visible = false;
            button2.Visible = false;
            btnTeacher.Visible = true;
            btnStaff.Visible = true;

            Thread thread2 = new Thread(new ThreadStart(ColorChange));
            thread2.Start();
            thread2.Abort();
        }

        private void ColorChange()
        {
            Random rndColor = new Random();
            while(this.button1.Visible == true || this.button2.Visible == true)
            {
                int red = rndColor.Next(1, 256);
                int green = rndColor.Next(1, 256);
                int blue = rndColor.Next(1, 256);
                this.button1.ForeColor = Color.FromArgb(red, green, blue);
                this.button2.ForeColor = Color.FromArgb(red, green, blue);
                Thread.Sleep(500);
            }
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer startMusic = new System.Media.SoundPlayer(@"D:\商務謝師夜\開始抽籤.wav");
                startMusic.Play();
            }
            catch
            {
                MessageBox.Show("確認音效位址");
            }

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            seatNo.Visible = true;
            groupNo.Visible = true;
            button2.Visible = true;
            button1.Visible = false;
            btnTeacher.Visible = false;
            btnStaff.Visible = false;

            Thread thread = new Thread(new ThreadStart(ColorChange));
            thread.Start();
            thread.Abort();


            try
            {
                int seat = teacher[countThree];

                seatNo.Text = "座位號碼：" + seat.ToString();
                countThree++;

                if (seat == 1)
                {
                    groupNo.Text = "分組組別：A";
                }
                else if (seat == 2)
                {
                    groupNo.Text = "分組組別：B";
                }
                else if (seat == 3)
                {
                    groupNo.Text = "分組組別：C";
                }
                else
                {
                    groupNo.Text = "分組組別：D";
                }
            }
            catch
            {
                MessageBox.Show("全員到齊！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer startMusic = new System.Media.SoundPlayer(@"D:\商務謝師夜\開始抽籤.wav");
                startMusic.Play();
            }
            catch
            {
                MessageBox.Show("確認音效位址");
            }

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            seatNo.Visible = true;
            groupNo.Visible = true;
            button2.Visible = true;
            button1.Visible = false;
            btnTeacher.Visible = false;
            btnStaff.Visible = false;

            Thread thread = new Thread(new ThreadStart(ColorChange));
            thread.Start();
            thread.Abort();


            try
            {
                int seat = staff[countStaff];

                seatNo.Text = "座位號碼：" + seat.ToString();
                countStaff++;

                if (seat == 1)
                {
                    groupNo.Text = "分組組別：A";
                }
                else if (seat == 8)
                {
                    groupNo.Text = "分組組別：B";
                }
                else if (seat == 16)
                {
                    groupNo.Text = "分組組別：C";
                }
                else
                {
                    groupNo.Text = "分組組別：D";
                }
            }
            catch
            {
                MessageBox.Show("全員到齊！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    
    }
}
