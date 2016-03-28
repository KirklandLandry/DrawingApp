using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HciDrawingProgram.Drawables
{
    class Polygon : Drawable // change it so right click starts new polygon and ends the current 1
    {
        Point start = new Point(-1, -1);
        Point current;
        Point previous;
        Point end = new Point(-1, -1);
        public List<Point> points;
        Pen pen = null;
        bool active;
        bool isClosed;

        public Polygon(bool closedPolygon)
        {
            active = true;
            points = new List<Point>();
            isClosed = closedPolygon;
        }

        public override void Update(int x, int y, Point prevPoint)
        {
            if (start.X == -1 && start.Y == -1)
            {
                //start = new Point(x, y);
                //previous = new Point(x, y);
                //points.Add(start);
                //points.Add(start);
            }
            current = new Point(x, y);
            //previous = prevPoint;
            /*else if (start.X != -1 && start.Y != -1)
            {
                end = new Point(x, y);
            }*/
            
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs g)
        {
            if (points.ToArray().Length >= 2)
                g.Graphics.DrawLines(pen, points.ToArray());
            if (base.drawMinMaxBoxes)
                g.Graphics.DrawRectangle(base.grayPen, base.minMaxRect);
        }


        public override void LeftMouseDown(Pen _pen)
        {
            if (pen == null)
                pen = new Pen(_pen.Color, _pen.Width);

            if (start.X == -1 && start.Y == -1)
            {
                start = new Point(current.X, current.Y);
                previous = new Point(current.X, current.Y);
                points.Add(start);
                points.Add(start);
            }
            else
            {
                points.Add(previous);
                points.Add(current);
                previous = current;
            }

        }
        public override void LeftMouseUp() 
        {

        }

        public override void RightMouseDown(Pen _pen) 
        {

            points.Add(start);
            end = previous;
            points.Add(end);
            active = false;

        }
        public override void RightMouseUp() { }

        public override void SetMinMaxPoints() 
        {
            int minX = points[0].X;
            int minY = points[0].Y;
            int maxX = points[0].X;
            int maxY = points[0].Y;

            for (int i = 1; i < points.Count(); i++)
            {
                if (points[i].X < minX)
                    minX = points[i].X;
                if (points[i].Y < minY)
                    minY = points[i].Y;
                if (points[i].X > maxX)
                    maxX = points[i].X;
                if (points[i].Y > maxY)
                    maxY = points[i].Y;
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
            for (int i = 0; i < points.Count(); i++)
            {
                points[i] = new Point(points[i].X + movX, points[i].Y + movY);
                SetMinMaxPoints();
            }
        }
    }
}
