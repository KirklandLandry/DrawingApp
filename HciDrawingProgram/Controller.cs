using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HciDrawingProgram
{
    class Controller
    {
        View view;
        DrawMode drawMode;
        DrawManager drawManager;

        bool constrainEllipseProportions;
        bool constrainRectangleProportions;


        public Controller()
        {
            view = new View();

            constrainEllipseProportions = false;
            constrainRectangleProportions = false;

            drawMode = DrawMode.freehand;

            drawManager = new DrawManager();

            InitializeViewEventHandlers();

            Layer a = drawManager.addLayer("Base Layer");    
            a.currentActiveLayer = true;
            a.listenOnDeleteLayerButton_Click += Layer_Handle_DeleteLayerButton_ClickEvent;
            a.visibleCheckBoxEvent += Layer_HandleVisibleCheckBoxEvent;
            view.AddLayer(drawManager.lastLayerAddedName, a);



            view.AddButtonColour(DrawMode.freehand, drawMode);
            view.SetLayerComboboxSelectedIndex(0);
            
            Application.Run(view);

        }


        private void InitializeViewEventHandlers()
        {
            view.freehandButton_ClickEvent += HandleFreehandButton_Click;
            view.lineButton_ClickEvent += HandleLineButton_Click;
            view.rectangleButton_ClickEvent += HandleRectangleButton_Click;
            view.ellipseButton_ClickEvent += HandleEllipseButton_Click;
            view.polygonButton_ClickEvent += HandlePolygonButton_Click;
            view.moveButton_ClickEvent += HandleMoveButton_Click;
            view.addLayerButton_ClickEvent += HandleAddLayerButton_Click;
            view.colourButton_ClickEvent += HandleColourButton1_Click;
            view.constrainRectangleProportionsCheckbox_CheckedChangedEvent += HandleConstrainRectangleProportionsCheckbox_CheckedChanged;
            view.constrainEllipseProportionsCheckbox_CheckedChangedEvent += HandleConstrainEllipseProportionsCheckbox_CheckedChanged;
            view.layerCombobox_SelectedIndexChangedEvent += HandleLayerCombobox_SelectedIndexChanged;
            view.canvas_MouseDownEvent += HandleCanvas_MouseDownEvent;
            view.canvas_MouseUpEvent += HandleCanvas_MouseUpEvent;
            view.canvas_MouseMoveEvent += HandleCanvas_MouseMoveEvent;
            view.canvas_PaintEvent += HandleCanvas_PaintEvent;
        }



        private void HandleFreehandButton_Click(object sender, EventArgs e)
        {
            drawMode = view.Update(DrawMode.freehand, drawMode);

        }

        private void HandleLineButton_Click(object sender, EventArgs e)
        {
            drawMode = view.Update(DrawMode.line, drawMode);
        }

        private void HandleRectangleButton_Click(object sender, EventArgs e)
        {
            drawMode = view.Update(DrawMode.rectangle, drawMode);
        }

        private void HandleEllipseButton_Click(object sender, EventArgs e)
        {
            drawMode = view.Update(DrawMode.ellipse, drawMode);
        }

        private void HandlePolygonButton_Click(object sender, EventArgs e)
        {
            drawMode = view.Update(DrawMode.polygon, drawMode);
        }

        private void HandleMoveButton_Click(object sender, EventArgs e)
        {
            drawMode = view.Update(DrawMode.move, drawMode);
        }

        private void HandleAddLayerButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("asdg");
            Layer a = drawManager.addLayer(view.GetAddLayerTextboxText());
            a.currentActiveLayer = true;
            a.listenOnDeleteLayerButton_Click += Layer_Handle_DeleteLayerButton_ClickEvent;
            a.visibleCheckBoxEvent += Layer_HandleVisibleCheckBoxEvent;
            view.AddLayer(drawManager.lastLayerAddedName, a);

            view.SetLayerComboboxSelectedIndex(drawManager.currentActiveIndex);

        }

        private void HandleColourButton1_Click(object sender, EventArgs e)
        {
            drawManager.leftClickPen.Color = view.GetColorDialogColor();
            
        }


        private void HandleConstrainRectangleProportionsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            constrainRectangleProportions = !constrainRectangleProportions;
        }

        private void HandleConstrainEllipseProportionsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            constrainEllipseProportions = !constrainEllipseProportions;

        }

        private void HandleLayerCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawManager.ChangeLayer(view.GetLayerComboboxSelectedIndex());
        }

        private void HandleCanvas_MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
                drawManager.MouseDown(drawMode, constrainRectangleProportions, constrainEllipseProportions);

        }

        private void HandleCanvas_MouseUpEvent(object sender, MouseEventArgs e)
        {
                if (e.Button.Equals(MouseButtons.Left)) 
            drawManager.MouseUp(drawMode);
        }

        private void HandleCanvas_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            drawManager.MouseMove(e, drawMode);
            view.RefreshView();
        }

        private void HandleCanvas_PaintEvent(object sender, PaintEventArgs e)
        {
            drawManager.Paint(e);
        }

        /*private void Handle_DeleteLayerButton_ClickEvent(object sender, PaintEventArgs e)
        {
            drawManager.DeleteLayer();
            view.RefreshView();
        }*/


        void Layer_HandleVisibleCheckBoxEvent(object o, EventArgs e)
        {
            view.RefreshView();
        }


        void Layer_Handle_DeleteLayerButton_ClickEvent(object o, EventArgs e)
        {
            int index = drawManager.DeleteLayer();
            if (index != -1)
                view.RemoveLayer(index);
            view.SetLayerComboboxSelectedIndex(drawManager.currentActiveIndex);

            view.RefreshView();
        }

    }
}
