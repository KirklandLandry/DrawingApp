using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HciDrawingProgram.Drawables
{
    class RectangleDrawable : Drawable
    {
        bool constrainProportions;
        Point start = new Point(-1, -1);
        Point end;
        Pen pen;

        public RectangleDrawable(bool _cp, int _id)
        {
            constrainProportions = _cp;
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
            if (constrainProportions)
            {
                double xDist = end.X - start.X;

                if (end.Y < start.Y)
                    g.Graphics.DrawRectangle(pen, Math.Min(start.X, end.X), start.Y - Math.Abs(end.X - start.X), Math.Abs(end.X - start.X), Math.Abs(end.X - start.X));
                else
                    g.Graphics.DrawRectangle(pen, Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(end.X - start.X), Math.Abs(end.X - start.X));
            }
            else if (start.X != -1 && start.Y != -1)
            {
                g.Graphics.DrawRectangle(pen, Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));
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
            Rectangle rect;

            if(constrainProportions)
            {
                if (end.Y < start.Y)
                    rect = new Rectangle(Math.Min(start.X, end.X), start.Y - Math.Abs(end.X - start.X), Math.Abs(end.X - start.X), Math.Abs(end.X - start.X));
                else
                    rect = new Rectangle(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(end.X - start.X), Math.Abs(end.X - start.X));

                minX = rect.X;
                maxX = rect.X + rect.Width;
                minY = rect.Y;
                maxY = rect.Y + rect.Height;
            }
            else
            {
                minX = Math.Min(start.X, end.X);
                maxX = Math.Max(start.X, end.X);
                minY = Math.Min(start.Y, end.Y);
                maxY = Math.Max(start.Y, end.Y);
                rect = new Rectangle(minX, minY, Math.Abs(maxX - minX), Math.Abs(maxY - minY));
            }         
            base.topLeft = new Point(rect.X, rect.Y);
            base.bottomRight = new Point(rect.X + rect.Width, rect.Y + rect.Y);
            base.minMaxRect = rect;
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
