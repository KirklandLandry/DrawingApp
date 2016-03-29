using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HciDrawingProgram.Drawables
{
    class Line : Drawable
    {
        Point start = new Point(-1, -1);
        Point end;
        Pen pen;

        public Line(int _id)
        {
            base.id = _id;
        }

        public override void Update(int x, int y, Point prevPoint)
        {
            if (start.X == -1 && start.Y == -1)
            {
                start = new Point(x, y);
            }
            else if (start.X != -1 && start.Y != -1)
            {
                end = new Point(x, y);
            }
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs g)
        {
                if (start.X != -1 && start.Y != -1)
                    g.Graphics.DrawLine(pen, start, end);
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
