using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lec_11
{
    public class Painter
    {
        public List<GradientFigure> figures;
        public Painter(List<GradientFigure> f)
        {
            figures = f;
        }
        public void Paint(Graphics g)
        {
            foreach(var r in figures)
            {
                r.Paint(g);
            }
        }
    }
}
