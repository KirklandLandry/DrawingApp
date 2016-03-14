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

        public virtual void Draw(System.Windows.Forms.PaintEventArgs g) { }
        //public virtual void Draw(Graphics g, Pen pen) { }
        public virtual void Update(int x, int y, Point prevPoint) { }
        public virtual void MouseDown(Pen _pen) { }
        public virtual void MouseUp() { }
        public virtual void ConstrainProportions() { }
    }
}
