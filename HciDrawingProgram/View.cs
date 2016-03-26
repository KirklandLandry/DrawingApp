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
    public partial class View : Form
    {

        public View()
        {
            InitializeComponent();
            
            freehandButton.BackColor = Color.LightSeaGreen;
  
            canvas.Image = new Bitmap(canvas.Width, canvas.Height);

            colourButton.BackColor = Color.Black;

            SetupFlowLayoutPanel();

        }

        private void SetupFlowLayoutPanel()
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.None;
            flowLayoutPanel1.WrapContents = false;
        }

        public void RemoveLayer(int index)
        {
            flowLayoutPanel1.Controls.RemoveAt(index);
            layerCombobox.Items.RemoveAt(index);
            //layerCombobox.Controls.Remove(index);
        }

        
        public void SetLayerComboboxSelectedIndex(int index)
        {
            layerCombobox.SelectedIndex = index;
        }





        #region BUTTON CLICK EVENTS
        public event EventHandler freehandButton_ClickEvent;
        private void freehandButton_Click(object sender, EventArgs e)
        {
            if (freehandButton_ClickEvent != null)
                freehandButton_ClickEvent(this, EventArgs.Empty);
        }

        public event EventHandler lineButton_ClickEvent;
        private void lineButton_Click(object sender, EventArgs e)
        {
            if (lineButton_ClickEvent != null)
                lineButton_ClickEvent(this, EventArgs.Empty);
        }

        public event EventHandler rectangleButton_ClickEvent;
        private void rectangleButton_Click(object sender, EventArgs e)
        {
            if (rectangleButton_ClickEvent != null)
                rectangleButton_ClickEvent(this, EventArgs.Empty);  
        }

        public event EventHandler ellipseButton_ClickEvent;
        private void ellipseButton_Click(object sender, EventArgs e)
        {
            if (ellipseButton_ClickEvent != null)
                ellipseButton_ClickEvent(this, EventArgs.Empty); 
        }

        public event EventHandler polygonButton_ClickEvent;
        private void polygonButton_Click(object sender, EventArgs e)
        {
            if (polygonButton_ClickEvent != null)
                polygonButton_ClickEvent(this, EventArgs.Empty);
        }

        public event EventHandler moveButton_ClickEvent;
        private void moveButton_Click(object sender, EventArgs e)
        {
            if (moveButton_ClickEvent != null)
                moveButton_ClickEvent(this, EventArgs.Empty);
            
        }

        public event EventHandler addLayerButton_ClickEvent;
        private void addLayerButton_Click(object sender, EventArgs e)
        {
            if (addLayerButton_ClickEvent != null)
                addLayerButton_ClickEvent(this, EventArgs.Empty);
            //AddLayer(addLayerTextbox.Text);
            addLayerTextbox.Text = "";
        }

        public string GetAddLayerTextboxText()
        {
            return addLayerTextbox.Text;
        }



        public void AddLayer(string name, Layer a)
        {


            layerCombobox.Items.Add(name);

            flowLayoutPanel1.Controls.Add(a);


            flowLayoutPanel1.ScrollControlIntoView(a);

        }

        public event EventHandler colourButton_ClickEvent;
        private void colourButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            colourButton.BackColor = colorDialog1.Color;

            if (colourButton_ClickEvent != null)
                colourButton_ClickEvent(this, EventArgs.Empty);

            
        }

        public Color GetColorDialogColor()
        {
            return colorDialog1.Color;
        }

        #endregion 


        public event EventHandler constrainRectangleProportionsCheckbox_CheckedChangedEvent;
        private void constrainRectangleProportionsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (constrainRectangleProportionsCheckbox_CheckedChangedEvent != null)
                constrainRectangleProportionsCheckbox_CheckedChangedEvent(this, EventArgs.Empty);
            
        }

        public event EventHandler constrainEllipseProportionsCheckbox_CheckedChangedEvent;
        private void constrainEllipseProportionsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (constrainEllipseProportionsCheckbox_CheckedChangedEvent != null)
                constrainEllipseProportionsCheckbox_CheckedChangedEvent(this, EventArgs.Empty);
        }

        public event EventHandler polygonClosedCheckbox_CheckedChangedEvent;
        private void polygonClosedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (polygonClosedCheckbox_CheckedChangedEvent != null)
                polygonClosedCheckbox_CheckedChangedEvent(this, EventArgs.Empty);
        }

        public event EventHandler layerCombobox_SelectedIndexChangedEvent;
        private void layerCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layerCombobox_SelectedIndexChangedEvent != null)
                layerCombobox_SelectedIndexChangedEvent(this, EventArgs.Empty);
            Console.WriteLine(layerCombobox.SelectedIndex);
        }

        public int GetLayerComboboxSelectedIndex()
        {
            return layerCombobox.SelectedIndex;
        }

        public event MouseEventHandler canvas_MouseDownEvent;
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (canvas_MouseDownEvent != null)
                canvas_MouseDownEvent(this, e);
        }

        public event MouseEventHandler canvas_MouseUpEvent;
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (canvas_MouseUpEvent != null)
                canvas_MouseUpEvent(this, e);
            
        }

        //Pen RightClickPen = new Pen(System.Drawing.Color.Black, 4); // not sure if I want to use this for eraser or second colour
        public event MouseEventHandler canvas_MouseMoveEvent;
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (canvas_MouseMoveEvent != null)
                canvas_MouseMoveEvent(this, e);
            
            //canvas.Refresh();
        }

        public event PaintEventHandler canvas_PaintEvent;
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (canvas_PaintEvent != null)
                canvas_PaintEvent(this, e);        
        }


        public DrawMode Update(DrawMode _drawMode, DrawMode drawMode)
        {
            if(AddButtonColour(_drawMode, drawMode))
                RemoveButtonColour(drawMode);
            //drawMode = _drawMode;
            return _drawMode;
        }

        #region CHANGE BUTTON COLOURS
        void RemoveButtonColour(DrawMode drawMode)
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
                case DrawMode.polygon:
                    polygonButton.BackColor = default(Color);
                    break;
                case DrawMode.move:
                    moveButton.BackColor = default(Color);
                    break;
            }
        }

        // set the colour of a button to indicate the currently selected draw mode
        public bool AddButtonColour(DrawMode _drawMode, DrawMode drawMode)
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
                case DrawMode.polygon:
                    polygonButton.BackColor = Color.LightSeaGreen;
                    break;
                case DrawMode.move:
                    moveButton.BackColor = Color.LightSeaGreen;
                    break;
            }
            return true;
        }
        #endregion 


        public void RefreshView()
        {
            canvas.Refresh();
        }





    }
}
