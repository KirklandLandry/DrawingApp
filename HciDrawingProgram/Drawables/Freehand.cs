using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HciDrawingProgram.Drawables
{
    class Freehand : Drawable
    {
        public List<Point> freehandPath;
        Pen pen;
        public override void Update(int x, int y, Point prevPoint)
        {
            Point pt = new Point(x, y);
            freehandPath.Add(prevPoint);
            freehandPath.Add(pt);
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs g)
        {
            if(freehandPath.ToArray().Length > 2)
                g.Graphics.DrawLines(pen, freehandPath.ToArray());
        }

        public override void LeftMouseDown(Pen _pen) 
        {
            pen = new Pen(_pen.Color, _pen.Width);
            freehandPath = new List<Point>();
        }
        public override void LeftMouseUp() 
        { 
        
        }
        public override void RightMouseDown(Pen _pen) { }
        public override void RightMouseUp() { }
    }
}
