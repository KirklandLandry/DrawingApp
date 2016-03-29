using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HciDrawingProgram
{
    public class Drawable
    {
        public Pen grayPen = new Pen(Color.SlateGray, 1);
        public int id;
        public Point topLeft, bottomRight;
        public Rectangle minMaxRect;
        public bool drawMinMaxBoxes;
        public virtual void SetDrawMinMaxBoxes(bool s) { }
        public virtual void Draw(System.Windows.Forms.PaintEventArgs g) { }
        //public virtual void Draw(Graphics g, Pen pen) { }
        public virtual void Update(int x, int y, Point prevPoint) { }
        public virtual void LeftMouseDown(Pen _pen) { }
        public virtual void LeftMouseUp() { }
        public virtual void RightMouseDown(Pen _pen) { }
        public virtual void RightMouseUp() { }
        public virtual void ConstrainProportions() { }
        public virtual void SetMinMaxPoints() { }
        public virtual void Move(int movX, int movY) { }
    }
}
