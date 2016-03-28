using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HciDrawingProgram
{
    public partial class Layer : UserControl
    {
        public int id;
        public bool deleteFlag;
        private bool CurrentActiveLayer; // if it's currently the active draw layer;
        public bool currentActiveLayer
        {
            get
            {
                return CurrentActiveLayer;
            }
            set
            {
                CurrentActiveLayer = value;
                if(value == true)
                {
                    currentLayerCheckBox.Checked = true;
                }
                else
                {
                    currentLayerCheckBox.Checked = false;
                }
            }
        }
        private bool Render;
        public bool render
        {
            get { return Render; }
            set { Render = value; }
        }
        private List<Drawable> drawables;

        public void AddDrawable(Drawable drawable)
        {
            drawables.Add(drawable);
        }
        public void RemoveDrawable(int index)
        {
            drawables.RemoveAt(index);
        }
        public Drawable GetDrawable(int i)
        {
            return drawables[i];
        }
        public int GetDrawablesCount()
        {
            return drawables.Count;
        }

        public Layer(int _id, string name)
        {
            InitializeComponent();
            id = _id;
            Console.WriteLine(id);
            render = false;
            visibleCheckBox.Checked = true;
            drawables = new List<Drawable>();
            groupBox.Text = name;
            deleteFlag = false;
        }

        /*public void Render()
        {
            for (int i = 0; i < drawables.Count; i++)
            {
                // draw it
            }
        }*/

        private void visibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            render = !render;
            if (visibleCheckBoxEvent != null)
                visibleCheckBoxEvent(this, EventArgs.Empty);
        }


        public event EventHandler visibleCheckBoxEvent;
        /*public void currentLayerCheckBoxChanged(object sender, EventArgs e)
        {

        }*/


        private void currentLayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            /*if (currentLayerCheckBox.Checked == false && currentActiveLayer)
                currentLayerCheckBox.Checked = true;
            else if (currentLayerCheckBox.Checked == true && !CurrentActiveLayer)
                currentLayerCheckBox.Checked = true;
            else if (currentLayerCheckBox.Checked == false && !CurrentActiveLayer)
                currentLayerCheckBox.Checked = false;*/
        }



        public void SetCurrentLayerCheckBox()
        {
            currentLayerCheckBox.Checked = true;
        }

        public void UnSetCurrentLayerCheckBox()
        {
            currentLayerCheckBox.Checked = false;
        }

        // this calls an event handler that will go and look for the missing 
        // id in the list of layers and destroy all references to it
        public event EventHandler listenOnDeleteLayerButton_Click;
        private void deleteLayerButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this layer?", "Delete Layer Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                deleteFlag = true;
                if (listenOnDeleteLayerButton_Click != null)
                    listenOnDeleteLayerButton_Click(this, EventArgs.Empty);
                //this.DestroyHandle();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        public void DestroyEvent()
        {
            // cleanup and destory this layer
        }

    }
}
