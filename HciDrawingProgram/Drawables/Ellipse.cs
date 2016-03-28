using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HciDrawingProgram.Drawables
{
    class Ellipse : Drawable
    {
        bool constrainProportions;
        Point start;// = new Point(-1, -1);
        Point end;
        Pen pen;

        int a = -1;

        public Ellipse(bool _cp)
        {
            constrainProportions = _cp;
        }

        public override void Update(int x, int y, Point prevPoint)
        {
            if (a == -1)
            {
                start = new Point(x, y);
                a = 1;
            }
            else if (a != -1)
            {
                end = new Point(x, y);

            }
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs g)
        {
            if (constrainProportions)
            {

                double xDist = end.X - start.X;
                double yDist = end.Y - start.Y;
                if(xDist > yDist)
                    g.Graphics.DrawEllipse(pen, start.X, start.Y, (float)xDist, (float)xDist);
                else
                    g.Graphics.DrawEllipse(pen, start.X, start.Y, (float)yDist, (float)yDist);

            }
            else if (start.X != -1 && start.Y != -1)
            {
                if (end.X > start.X && end.Y > start.Y)
                    g.Graphics.DrawEllipse(pen, start.X, start.Y, end.X - start.X, end.Y - start.Y);

                else if (end.X < start.X && end.Y > start.Y)
                    g.Graphics.DrawEllipse(pen, end.X, start.Y, start.X - end.X, end.Y - start.Y);

                else if (end.X > start.X && end.Y < start.Y)
                    g.Graphics.DrawEllipse(pen, start.X, end.Y, end.X - start.X, start.Y - end.Y);

                else if (end.X < start.X && end.Y < start.Y)
                    g.Graphics.DrawEllipse(pen, end.X, end.Y, start.X - end.X, start.Y - end.Y);
            }
            if (base.drawMinMaxBoxes)
                g.Graphics.DrawRectangle(base.grayPen, base.minMaxRect);
        }
        public override void LeftMouseDown(Pen _pen)
        {
            pen = new Pen(_pen.Color, _pen.Width);
        }
        public override void LeftMouseUp() { }
        public override void RightMouseDown(Pen _pen) { }
        public override void RightMouseUp() { }
        public override void ConstrainProportions()
        {
            constrainProportions = !constrainProportions;
        }
        public override void SetMinMaxPoints()
        {
            int minX;
            int minY;
            int maxX;
            int maxY;

            if (start.X < end.X)
            {
                minX = start.X;
                maxX = end.X;
            }
            else
            {
                minX = end.X;
                maxX = start.X;
            }
            if (start.Y < end.Y)
            {
                minY = start.Y;
                maxY = end.Y;
            }
            else
            {
                minY = end.Y;
                maxY = start.Y;
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
            start = new Point(start.X + movX, start.Y + movY);
            end = new Point(end.X + movX, end.Y + movY);
            SetMinMaxPoints();
        }
    }
}
