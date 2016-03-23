﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HciDrawingProgram
{
    public class Drawable
    {

        public virtual void Draw(System.Windows.Forms.PaintEventArgs g) { }
        //public virtual void Draw(Graphics g, Pen pen) { }
        public virtual void Update(int x, int y, Point prevPoint) { }
        public virtual void LeftMouseDown(Pen _pen) { }
        public virtual void LeftMouseUp() { }
        public virtual void ConstrainProportions() { }
    }
}
