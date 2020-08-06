using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Canvas
{
    public partial class Form1 : Form
    {
        public Bitmap BM = new Bitmap(1366,768);
        Pen pe = new Pen(Color.Black, 3);
        bool draw = false;

        public Form1()
        {

            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = !draw;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics G = Graphics.FromImage(BM);
                G.DrawEllipse(pe, e.X, e.Y,3,3);
                pictureBox1.Image = BM;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pe.Color = Color.Black;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            pe.Color = Color.Red;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            pe.Color = Color.Blue;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            pe.Color = Color.Green;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pe.Color = Color.Yellow;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            pe.Color = Color.Orange;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            pe.Color = Color.White;
            pe.Width = 10;
        }

        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Jpeg Image |*.jpg| Bitmap Image (*.bmp)|*.bmp";
            sf.Title = "Save Image";
            sf.ShowDialog();
            if (sf.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)sf.OpenFile();
                switch (sf.FilterIndex)
                {
                    case 1:
                        {
                            this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        }
                    case 2:
                        {
                            this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        }
                }

            }
        }

    }
}
