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
        public bool render;
        List<Drawable> drawables;

        public Layer(int _id, string name)
        {
            InitializeComponent();
            id = _id;
            Console.WriteLine(id);
            render = true;
            visibleCheckBox.Checked = true;
            drawables = new List<Drawable>();
            groupBox.Text = name;
        }

        public void Render()
        {
            for (int i = 0; i < drawables.Count; i++)
            {
                // draw it
            }
        }

        private void visibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            render = !render;
        }


        //public event EventHandler currentLayerCheckBoxChanged;
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

    }
}
