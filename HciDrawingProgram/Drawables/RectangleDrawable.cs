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

        public RectangleDrawable(bool _cp)
        {
            constrainProportions = _cp;
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
                //double yDist = end.Y - start.Y;
                //double size = Math.Sqrt((xDist*xDist) + (yDist*yDist));
                //g.Graphics.DrawRectangle(pen, start.X, start.Y, (float)size, (float)size);

                //if (end.X > start.X && end.Y > start.Y)
                //{
                    double xDist = end.X - start.X;

                    g.Graphics.DrawRectangle(pen, start.X, start.Y, (float)xDist, (float)xDist);
                //}   
                /*else
                {
                    double xDist = start.X - end.X;
                    double yDist = end.Y - start.Y;

                    g.Graphics.DrawRectangle(pen, end.X, end.Y, (float)yDist, (float)yDist);
                }*/
                    
            }
            else if (start.X != -1 && start.Y != -1)
            {
                if(end.X > start.X && end.Y > start.Y)
                    g.Graphics.DrawRectangle(pen, start.X, start.Y, end.X - start.X, end.Y - start.Y);

                else if (end.X < start.X && end.Y > start.Y)
                    g.Graphics.DrawRectangle(pen, end.X, start.Y, start.X - end.X, end.Y - start.Y);

                else if (end.X > start.X && end.Y < start.Y)
                    g.Graphics.DrawRectangle(pen, start.X, end.Y, end.X - start.X, start.Y - end.Y);

                else if (end.X < start.X && end.Y < start.Y)
                    g.Graphics.DrawRectangle(pen, end.X, end.Y, start.X - end.X, start.Y - end.Y);
            }
        }
        public override void LeftMouseDown(Pen _pen)
        {
            constrainProportions = false;
            pen = new Pen(_pen.Color, _pen.Width);
        }
        public override void LeftMouseUp() { }
        public override void RightMouseDown(Pen _pen) { }
        public override void RightMouseUp() { }
        public override void ConstrainProportions() 
        {
            constrainProportions = !constrainProportions;
        }


    }
}
