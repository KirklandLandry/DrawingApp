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

        int movementIdCounter;
        Point drawableCurrentlyBeingMoved; // this stores the layer its in (x) and the drawable in the layer's drawables array (y)

        public Pen leftClickPen = new Pen(System.Drawing.Color.Black, 4);
        Point prevPt;

        public DrawManager()
        {
            drawables = new List<Drawable>();
            layers = new List<Layer>();
            currentActiveIndex = 0;
            layerCount = 0;
            mouseDown = false;
            movementIdCounter = 0;
            drawableCurrentlyBeingMoved = new Point(-1, -1);
        }

        public void ChangeMinMaxBoxDraw(bool s)
        {
            for (int n = 0; n < layers.Count; n++)
            {
                for (int i = 0; i < layers[n].GetDrawablesCount(); i++)
                {
                    layers[n].GetDrawable(i).SetDrawMinMaxBoxes(s);
                }
            }
        }

        public void CreatePolygon(bool closedPolygon)
        {
            currentDrawable = new Polygon(closedPolygon);
        }

        public void LeftMouseDown(DrawMode drawMode, bool constrainRectangle, bool constrainEllipse, MouseEventArgs e)
        {
            mouseDown = true;
            if (layers[currentActiveIndex].render)
            {
                
                switch (drawMode)
                {
                    case DrawMode.freehand:
                        currentDrawable = new Freehand(movementIdCounter++);
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
                        
                        break;
                    case DrawMode.move:
                        SelectDrawableToMove(e);
                        break;
                }
                if (drawMode != DrawMode.move && currentDrawable != null)
                    currentDrawable.LeftMouseDown(leftClickPen);
            }
        }

        private void SelectDrawableToMove(MouseEventArgs e)
        {
            int _id = -1;
            drawableCurrentlyBeingMoved.X = -1;
            drawableCurrentlyBeingMoved.Y = -1;

            for (int n = 0; n < layers.Count; n++)
            {
                for (int i = 0; i < layers[n].GetDrawablesCount(); i++)
                {
                    Rectangle shapeBounds = layers[n].GetDrawable(i).minMaxRect;

                    if(e.X > shapeBounds.X && e.X < shapeBounds.X + shapeBounds.Width &&
                        e.Y > shapeBounds.Y && e.Y < shapeBounds.Y + shapeBounds.Height)
                    {
                        if (layers[n].GetDrawable(i).id > _id)
                        {
                            _id = layers[n].GetDrawable(i).id;
                            drawableCurrentlyBeingMoved.X = n;
                            drawableCurrentlyBeingMoved.Y = i;
                        }
                    }
                }
            }
        }

        public void RightMouseDown(DrawMode drawMode)
        {
            if (layers[currentActiveIndex].render && currentDrawable != null && drawMode == DrawMode.polygon)
            {
                currentDrawable.RightMouseDown(leftClickPen);
                currentDrawable.SetMinMaxPoints();
                layers[currentActiveIndex].AddDrawable(currentDrawable);
                currentDrawable = null;
            }
        }


        public void MouseUp(DrawMode drawMode)
        {
            if (drawMode == DrawMode.move)
            {
                drawableCurrentlyBeingMoved.X = -1;
                drawableCurrentlyBeingMoved.Y = -1;
            }
            else if (layers[currentActiveIndex].render && drawMode == DrawMode.polygon && currentDrawable != null)
            {
                currentDrawable.LeftMouseUp();
            }
            else if (layers[currentActiveIndex].render && drawMode != DrawMode.move && currentDrawable != null)
            {
                
                currentDrawable.LeftMouseUp();
                //drawables.Add(currentDrawable);
                layers[currentActiveIndex].AddDrawable(currentDrawable);
                currentDrawable.SetMinMaxPoints();
                currentDrawable = null;
            }
            mouseDown = false;
        }

        public void MouseMove(MouseEventArgs e, DrawMode drawMode)
        {
            if(drawableCurrentlyBeingMoved.X != -1 && drawableCurrentlyBeingMoved.Y != -1)
            {
                int movX = e.X - prevPt.X;
                int movY = e.Y - prevPt.Y;
                int a = drawableCurrentlyBeingMoved.X;
                layers[a].GetDrawable(drawableCurrentlyBeingMoved.Y).Move(movX, movY);
            }
            else if (drawMode == DrawMode.polygon && layers[currentActiveIndex].render && currentDrawable != null)
            {
                currentDrawable.Update(e.X, e.Y, prevPt);
            }
            else if (mouseDown && (layers[currentActiveIndex].render) && drawMode != DrawMode.move && currentDrawable != null)
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
