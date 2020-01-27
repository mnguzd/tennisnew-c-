using System;
using System.Drawing;
using System.Windows.Forms;
namespace TenisNew
{
    public partial class Form1 : Form
    {
        public Bitmap Ball = Resource1.ebalo;
        public Bitmap Wall = Resource1.wall;
        int x = 50; int y = 50; int z = 422; int j = 473;
        int x1 = 3; int y1 = 3;int width2; int i;
        Random pand = new Random();
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles(); Rand(); Interface();
            width2 = 150;
        }
        public void Rand()
        {
            int napr = pand.Next(0, 2);
            x1 = napr == 0 ? pand.Next(3, 5) : -pand.Next(3, 5); y1 = pand.Next(3, 5);
            x = pand.Next(100, 800); y = pand.Next(100, 200);
            Refresh();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (z+width2 > 910)
                timer2.Enabled = false;
            if(z<8)
                timer3.Enabled = false;
            Refresh();
            x += x1; y += y1;
            if (x + 16 > z - 7 && x + 16 < z + 7 + width2 && y + 32 > 470)
            {
                width2 = width2 > 20 ? width2 - 10 : width2;
                y1 = x1 > 0 && y1 > 0 ? -y1 : x1 < 0 && y1 > 0 ? -y1 : -y1;
            }
            if (x + 32 > 900)
                x1 = x1 > 0 && y1 < 0 ? -x1 : x1 > 0 && y1 > 0 ? -x1 : -x1;
            if (y < 3)
                y1 = x1 < 0 && y1 < 0 ? -y1 : x1 > 0 && y1 < 0 ? -y1 : -y1;
            if (x < 3)
                x1 = x1 < 0 && y1 > 0 ? -x1 : x1 < 0 && y1 < 0 ? -x1 : -x1;
            if (y+32> 500)
                Interface();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.D)
                    timer2.Enabled = true;
            if (e.KeyValue == (char)Keys.A)
                timer3.Enabled = true;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            z += 6;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            z -= 6;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            timer2.Enabled = false; timer3.Enabled = false;
        }
        void Interface()
        {
            timer1.Enabled = false;
            button1.Show();
            Rand();
            label1.Hide();
            i = 3; z = 422; j = 473;
        }
        void Game()
        {
            width2 = 150;
            button1.Hide();
            timer1.Enabled = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                Graphics g = e.Graphics;
                g.DrawImage(Ball, new Rectangle(x, y, 32, 32));
                g.DrawImage(Wall, new Rectangle(z, j, width2, 25));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer4.Enabled = true; button1.Hide();
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
                label1.Text = i.ToString(); label1.Show();
                i--;
                if (i == -1)
                {
                    label1.Hide();
                    Game();
                    timer4.Enabled = false;
                }
        }
    }
}
