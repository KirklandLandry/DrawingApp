using HciDrawingProgram.Drawables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HciDrawingProgram
{
    class DrawManager
    {
        List<Drawable> drawables;
        List<Layer> layers;
        Drawable currentDrawable;

        public int currentActiveIndex;
        int layerCount;
        bool mouseDown;

        public Pen leftClickPen = new Pen(System.Drawing.Color.Black, 4);
        Point prevPt;

        public DrawManager()
        {
            drawables = new List<Drawable>();
            layers = new List<Layer>();
            currentActiveIndex = 0;
            layerCount = 0;
            mouseDown = false;

        }

        public void MouseDown(DrawMode drawMode, bool constrainRectangle, bool constrainEllipse)
        {
            mouseDown = true;
            if (layers[currentActiveIndex].render)
            {
                
                switch (drawMode)
                {
                    case DrawMode.freehand:
                        currentDrawable = new Freehand();
                        break;
                    case DrawMode.line:
                        currentDrawable = new Line();
                        break;
                    case DrawMode.rectangle:
                        currentDrawable = new RectangleDrawable(constrainRectangle);
                        break;
                    case DrawMode.ellipse:
                        currentDrawable = new Ellipse(constrainEllipse);
                        break;
                    case DrawMode.polygon:
                        currentDrawable = new Polygon();
                        break;
                    case DrawMode.move:

                        break;
                }
                if (drawMode != DrawMode.move)
                    currentDrawable.LeftMouseDown(leftClickPen);
            }
        }


        public void MouseUp(DrawMode drawMode)
        {
            if (layers[currentActiveIndex].render & drawMode != DrawMode.move)
            {
                
                currentDrawable.LeftMouseUp();
                //drawables.Add(currentDrawable);
                layers[currentActiveIndex].AddDrawable(currentDrawable);
                currentDrawable = null;
            }
            mouseDown = false;
        }

        public void MouseMove(MouseEventArgs e, DrawMode drawMode)
        {
            if (mouseDown && (layers[currentActiveIndex].render) && drawMode != DrawMode.move)
            {
                currentDrawable.Update(e.X, e.Y, prevPt);
                //pictureBox1.Refresh();
            }
            prevPt = new Point(e.X, e.Y);
        }


        public void Paint(PaintEventArgs e)
        {
            for (int n = 0; n < layers.Count; n++)
            {
                if (layers[n].render)
                {
                    for (int i = 0; i < layers[n].GetDrawablesCount(); i++)
                    {
                        layers[n].GetDrawable(i).Draw(e);
                    }
                }
            }
            if (layers[currentActiveIndex].render)
            {
                try
                {
                    if (currentDrawable != null)
                        currentDrawable.Draw(e);
                }
                catch { }
            }
        }

        public int DeleteLayer()
        {
            if (layers.Count <= 1) // this isn't really working. need to change all this indexing stuff to be less messy
            {
                // can't delete the only layer
            }
            else
            {
                int tempCount = layers.Count;
                for (int i = 0; i < tempCount; i++)
                {
                    if (layers[i].deleteFlag)
                    {
                        // call the layer's DestroyEvent() function
                        layers.RemoveAt(i);
                        if (currentActiveIndex == 0)
                            currentActiveIndex = 0;//++;
                        else
                            currentActiveIndex--;
                        //layerCount--;
                        return i;
                        //pictureBox1.Refresh();
                    }
                }
            }
            return -1;
        }

        public void ChangeLayer(int selectedComboboxIndex)
        {
            layers[currentActiveIndex].currentActiveLayer = false;
            layers[selectedComboboxIndex].currentActiveLayer = true;
            currentActiveIndex = selectedComboboxIndex;
        }



        public string lastLayerAddedName;
        public Layer addLayer(string name)
        {
            if (name == "")
                name = "Layer " + layerCount;
            lastLayerAddedName = name;
            Layer a = new Layer(layerCount++, name);
            a.Visible = true;
            layers.Add(a);

            layers[currentActiveIndex].currentActiveLayer = false;
            currentActiveIndex = layers.Count - 1;


            return a;
        }

    }
}
