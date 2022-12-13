using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Security.Policy;

namespace OOP_lec_11
{
    public partial class Form1 : Form
    {
        private List<GradientFigure> gfs = new ();

        private Painter p;
        private Point? downOn = null;
        public Form1()
        {
            InitializeComponent();
            //r = new GradientRectangle
            //{
            //    X = 10,
            //    Y = 10,
            //    Width = 110,
            //    Height = 110,
            //    Color1 = Color.BlueViolet,
            //    Color2 = Color.Bisque,
            //    ColorAngle = 90
            //};
            p = new Painter(gfs);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //Graphics g = panel1.CreateGraphics();
            //var rect = new Rectangle(30, 40, 250, 200);
            //var brush = new SolidBrush(Color.Black);
            //g.FillRectangle(brush, rect);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        //    //Graphics g = e.Graphics;
        //    //var rect = new Rectangle(30, 40, 250, 200);
        //    ////var brush = new SolidBrush(Color.Black);
        //    //var brush = new LinearGradientBrush(rect, Color.Black, Color.Blue, 45);
        //    //var pen = new Pen(Color.Green, 10);
        //    //g.DrawRectangle(pen, rect);
        //    //g.FillRectangle(brush, rect);
              p.Paint(e.Graphics);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
                foreach (var f in gfs)
                {
                    if (f.ContainsPoint(e.Location))
                    {
                        downOn = e.Location;
                        break;
                    }
                }
            else if (MouseButtons == MouseButtons.Right)
            {
                GradientFigure? gf = null;
                if (radioButton1.Checked)
                {
                    // Прямоугольник
                    gf = new GradientRectangle();
                }
                else if (radioButton2.Checked)
                {
                    // Овал
                    gf = new GradientOval();
                }
                if (gf != null)
                {
                    gf.AddPoint(e.Location);
                    gf.Color1 = Color.BlueViolet;
                    gf.Color2 = Color.Bisque;
                    gf.ColorAngle = 90;
                    downOn = e.Location;
                    gfs.Add(gf);
                    downOn = e.Location;
                }
                
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            downOn = null;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (downOn is {} point)
            {
                if (e.Button == MouseButtons.Left)
                {
                    var currPoint = e.Location;
                    var dx = currPoint.X - point.X;
                    var dy = currPoint.Y - point.Y;
                    downOn = currPoint;
                    GradientFigure? f = null;
                    foreach (var gf in gfs)
                    {
                        if (gf.ContainsPoint(e.Location))
                        {
                            f = gf;
                            break;
                        }
                    }
                    if (f != null)
                    {
                        f.Move(dx, dy);
                        panel1.Refresh();
                    }
                } else if (e.Button == MouseButtons.Right)
                {
                    gfs[^1].AddPoint(e.Location);
                    panel1.Refresh();
                }
            }
            
        }
    }
}