using HciDrawingProgram.Drawables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HciDrawingProgram
{
    public partial class Form1 : Form
    {

        // BUG: most recent object drawn sometimes gets messed up on the layers
        // disappears or not on any layer
        // or on the wrong layer (draw, add layer -> it's on the new layer)
        // this must be because of the add order 

        List<Layer> layers;
        List<Drawable> drawables;
        Drawable currentDrawable;

        int layerCount;
        public Form1()
        {
            InitializeComponent();
            AddButtonColour(DrawMode.freehand);
            freehandButton.BackColor = Color.LightSeaGreen;
            constrainEllipseProportions = false;
            constrainRectangleProportions = false;
            mouseDown = false;


            drawables = new List<Drawable>();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);


            layerCount = 0;
            layers = new List<Layer>();

            colourButton1.BackColor = Color.Black;

            currentActiveIndex = 0;



            AddLayer("Base Layer");
            comboBox1.SelectedIndex = 0;


            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.None;
            flowLayoutPanel1.WrapContents = false;
        }


        int currentActiveIndex;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedIndex);
            layers[currentActiveIndex].currentActiveLayer = false;
            layers[comboBox1.SelectedIndex].currentActiveLayer = true;
            currentActiveIndex = comboBox1.SelectedIndex;
        }



        DrawMode drawMode;

        bool constrainEllipseProportions;
        bool constrainRectangleProportions;
        bool mouseDown;


        private void freehandButton_Click(object sender, EventArgs e)
        {
            Update(DrawMode.freehand);
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            Update(DrawMode.line);
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            Update(DrawMode.rectangle);
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            Update(DrawMode.ellipse);
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            Update(DrawMode.move);
        }

        private void constrainRectangleProportionsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            constrainRectangleProportions = !constrainRectangleProportions;
        }

        private void constrainEllipseProportionsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            constrainEllipseProportions = !constrainEllipseProportions;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (layers[currentActiveIndex].render)
            {
                mouseDown = true;
                switch (drawMode)
                {
                    case DrawMode.freehand:
                        currentDrawable = new Freehand();
                        break;
                    case DrawMode.line:
                        currentDrawable = new Line();
                        break;
                    case DrawMode.rectangle:
                        currentDrawable = new RectangleDrawable(constrainRectangleProportionsCheckbox.Checked);
                        break;
                    case DrawMode.ellipse:
                        currentDrawable = new Ellipse(constrainEllipseProportionsCheckbox.Checked);
                        break;
                    case DrawMode.move:

                        break;
                }
                if(drawMode != DrawMode.move)
                    currentDrawable.MouseDown(leftClickPen);
            }
        }


        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (layers[currentActiveIndex].render & drawMode != DrawMode.move)
            {
                mouseDown = false;
                currentDrawable.MouseUp();
                //drawables.Add(currentDrawable);
                layers[currentActiveIndex].AddDrawable(currentDrawable);
                currentDrawable = null;
            }
        }

        Point prevPt;

        Pen leftClickPen = new Pen(System.Drawing.Color.Black, 4);
        //Pen RightClickPen = new Pen(System.Drawing.Color.Black, 4); // not sure if I want to use this for eraser or second colour
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown && (layers[currentActiveIndex].render) && drawMode != DrawMode.move)
            {
                currentDrawable.Update(e.X, e.Y, prevPt);
                pictureBox1.Refresh();
            }
            prevPt = new Point(e.X, e.Y);
        }


        void Update(DrawMode _drawMode)
        {
            if(AddButtonColour(_drawMode))
                RemoveButtonColour();
            drawMode = _drawMode;
        }

        #region CHANGE BUTTON COLOURS
        void RemoveButtonColour()
        {
            switch (drawMode)
            {
                case DrawMode.freehand:
                    freehandButton.BackColor = default(Color);
                    break;
                case DrawMode.line:
                    lineButton.BackColor = default(Color);
                    break;
                case DrawMode.rectangle:
                    rectangleButton.BackColor = default(Color);
                    break;
                case DrawMode.ellipse:
                    ellipseButton.BackColor = default(Color);
                    break;
                case DrawMode.move:
                    moveButton.BackColor = default(Color);
                    break;
            }
        }

        // set the colour of a button to indicate the currently selected draw mode
        bool AddButtonColour(DrawMode _drawMode)
        {
            // if you're pressing the already selected button
            if (drawMode == _drawMode)
                return false;
            switch (_drawMode)
            {
                case DrawMode.freehand:
                    freehandButton.BackColor = Color.LightSeaGreen;
                    break;
                case DrawMode.line:
                    lineButton.BackColor = Color.LightSeaGreen;
                    break;
                case DrawMode.rectangle:
                    rectangleButton.BackColor = Color.LightSeaGreen;
                    break;
                case DrawMode.ellipse:
                    ellipseButton.BackColor = Color.LightSeaGreen;
                    break;
                case DrawMode.move:
                    moveButton.BackColor = Color.LightSeaGreen;
                    break;
            }
            return true;
        }
        #endregion 

        private void panel_Paint(object sender, PaintEventArgs e)
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

        private void addLayerButton_Click(object sender, EventArgs e)
        {
            AddLayer(addLayerTextbox.Text);
            addLayerTextbox.Text = "";
        }

        void AddLayer(string name)
        {
            if(name == "")
                name = "Layer " + layerCount;
            comboBox1.Items.Add(name);

            Layer a = new Layer(layerCount++, name);
            a.Visible = true;
            flowLayoutPanel1.Controls.Add(a);
            layers.Add(a);

            layers[currentActiveIndex].currentActiveLayer = false;
            currentActiveIndex = layerCount - 1;
            a.currentActiveLayer = true;
            flowLayoutPanel1.ScrollControlIntoView(a);
            a.listenOnDeleteLayerButton_Click += Handle_DeleteLayerButton_ClickEvent;
            a.visibleCheckBoxEvent += HandleVisibleCheckBoxEvent;
        }

        private void colourButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            colourButton1.BackColor = colorDialog1.Color;
            leftClickPen.Color = colorDialog1.Color;
        }


        void HandleVisibleCheckBoxEvent(object o, EventArgs e)
        {
            pictureBox1.Refresh();

        }



        void Handle_DeleteLayerButton_ClickEvent(object o, EventArgs e)
        {
            Console.WriteLine("ha");
            if (layers.Count <= 1) // this isn't really working. need to change all this indexing stuff to be less messy
            {
                // can't delete the only layer
            }
            else
            {
                for (int i = 0; i < layers.Count; i++)
                {
                    if (layers[i].deleteFlag)
                    {
                        // call the layer's DestroyEvent() function
                        layers.RemoveAt(i);
                        if (currentActiveIndex == 0)
                            currentActiveIndex++;
                        else
                            currentActiveIndex--;
                        layerCount--;
                        pictureBox1.Refresh();
                    }
                }
            }
        }



    }
}
