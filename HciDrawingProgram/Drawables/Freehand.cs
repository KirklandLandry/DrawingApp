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

        public Freehand(int _id)
        {
            base.id = _id;
        }

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
            if (base.drawMinMaxBoxes)
            {
                g.Graphics.DrawRectangle(base.grayPen, base.minMaxRect);
            }
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
        public override void SetMinMaxPoints()
        {
            int minX = freehandPath[0].X;
            int minY = freehandPath[0].Y;
            int maxX = freehandPath[0].X;
            int maxY = freehandPath[0].Y;

            for(int i = 1; i < freehandPath.Count(); i++)
            {
                if (freehandPath[i].X < minX)
                    minX = freehandPath[i].X;
                if (freehandPath[i].Y < minY)
                    minY = freehandPath[i].Y;
                if (freehandPath[i].X > maxX)
                    maxX = freehandPath[i].X;
                if (freehandPath[i].Y > maxY)
                    maxY = freehandPath[i].Y;
            }
            base.topLeft = new Point(minX, minY);
            base.bottomRight = new Point(maxX, maxY);
            base.minMaxRect = new Rectangle(base.topLeft.X, base.topLeft.Y, Math.Abs(base.bottomRight.X - base.topLeft.X), Math.Abs(base.bottomRight.Y - base.topLeft.Y));

        }
        public override void SetDrawMinMaxBoxes(bool s) 
        {
            base.drawMinMaxBoxes = s;
        }
        public override void Move(int movX, int movY) 
        {
            for (int i = 0; i < freehandPath.Count(); i++)
            {
                freehandPath[i] = new Point(freehandPath[i].X + movX,freehandPath[i].Y + movY);
                SetMinMaxPoints();
            }
        }
    }
}
