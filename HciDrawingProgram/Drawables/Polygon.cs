﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HciDrawingProgram.Drawables
{
    class Polygon : Drawable
    {
        Point start = new Point(-1, -1);
        Point end;
        Pen pen;

        public Polygon()
        {
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

        }
        public override void LeftMouseDown(Pen _pen)
        {
            pen = new Pen(_pen.Color, _pen.Width);
        }
        public override void LeftMouseUp() 
        {

        }

    }
}