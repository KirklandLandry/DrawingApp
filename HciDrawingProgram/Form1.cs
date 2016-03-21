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

        DrawManager drawManager;

        
        public Form1()
        {
            InitializeComponent();
            AddButtonColour(DrawMode.freehand);
            freehandButton.BackColor = Color.LightSeaGreen;
            constrainEllipseProportions = false;
            constrainRectangleProportions = false;

            drawManager = new DrawManager();
            
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);


            

            colourButton1.BackColor = Color.Black;


            AddLayer("Base Layer");
            comboBox1.SelectedIndex = 0;


            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.None;
            flowLayoutPanel1.WrapContents = false;
        }


        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedIndex);
            drawManager.ChangeLayer(comboBox1.SelectedIndex);
        }



        DrawMode drawMode;

        bool constrainEllipseProportions;
        bool constrainRectangleProportions;

        #region BUTTON CLICK EVENTS
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

        private void addLayerButton_Click(object sender, EventArgs e)
        {
            AddLayer(addLayerTextbox.Text);
            addLayerTextbox.Text = "";
        }

        private void colourButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            colourButton1.BackColor = colorDialog1.Color;
            drawManager.leftClickPen.Color = colorDialog1.Color;
        }
        #endregion 



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
            drawManager.MouseDown(drawMode, constrainRectangleProportionsCheckbox.Checked, constrainEllipseProportionsCheckbox.Checked);
        }


        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drawManager.MouseUp(drawMode);
        }


        //Pen RightClickPen = new Pen(System.Drawing.Color.Black, 4); // not sure if I want to use this for eraser or second colour
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            drawManager.MouseMove(e, drawMode);
            pictureBox1.Refresh();
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
            drawManager.Paint(e);
        }



        void AddLayer(string name)
        {

            Layer a = drawManager.addLayer(name);
            comboBox1.Items.Add(drawManager.lastLayerAddedName);


            flowLayoutPanel1.Controls.Add(a);
            


            a.currentActiveLayer = true;
            a.listenOnDeleteLayerButton_Click += Handle_DeleteLayerButton_ClickEvent;
            a.visibleCheckBoxEvent += HandleVisibleCheckBoxEvent;
            flowLayoutPanel1.ScrollControlIntoView(a);

        }




        void HandleVisibleCheckBoxEvent(object o, EventArgs e)
        {
            pictureBox1.Refresh();

        }



        void Handle_DeleteLayerButton_ClickEvent(object o, EventArgs e)
        {
            drawManager.DeleteLayer();
            pictureBox1.Refresh();
        }

        void RefreshView()
        {

        }

    }
}
