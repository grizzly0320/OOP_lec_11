using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lec_11
{
    public class GradientOval : GradientFigure
    {
        public override void Paint(Graphics g)
        {
            try
            {
                var p = new Pen(BorderColor);
                var b = new LinearGradientBrush(Rectangle, Color1, Color2, ColorAngle);
                g.FillEllipse(b, Rectangle);
                g.DrawEllipse(p, Rectangle);
            }
            catch { }
        }
    }
}
