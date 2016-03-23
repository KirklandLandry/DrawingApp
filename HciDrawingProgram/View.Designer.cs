namespace HciDrawingProgram
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label selectedColourLabel;
            this.freehandButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.constrainRectangleProportionsCheckbox = new System.Windows.Forms.CheckBox();
            this.constrainEllipseProportionsCheckbox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.layerCombobox = new System.Windows.Forms.ComboBox();
            this.addLayerButton = new System.Windows.Forms.Button();
            this.addLayerTextbox = new System.Windows.Forms.TextBox();
            this.colourButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.polygonButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.brushWidthSlider = new System.Windows.Forms.Label();
            this.moveButton = new System.Windows.Forms.Button();
            selectedColourLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedColourLabel
            // 
            selectedColourLabel.AutoSize = true;
            selectedColourLabel.Location = new System.Drawing.Point(742, 198);
            selectedColourLabel.Name = "selectedColourLabel";
            selectedColourLabel.Size = new System.Drawing.Size(37, 13);
            selectedColourLabel.TabIndex = 12;
            selectedColourLabel.Text = "Colour";
            // 
            // freehandButton
            // 
            this.freehandButton.BackColor = System.Drawing.SystemColors.Control;
            this.freehandButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.freehandButton.Location = new System.Drawing.Point(743, 13);
            this.freehandButton.Name = "freehandButton";
            this.freehandButton.Size = new System.Drawing.Size(75, 23);
            this.freehandButton.TabIndex = 1;
            this.freehandButton.Text = "freehand";
            this.freehandButton.UseVisualStyleBackColor = false;
            this.freehandButton.Click += new System.EventHandler(this.freehandButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(743, 43);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 2;
            this.lineButton.Text = "line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Location = new System.Drawing.Point(743, 73);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(75, 23);
            this.rectangleButton.TabIndex = 3;
            this.rectangleButton.Text = "rectangle";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Location = new System.Drawing.Point(743, 101);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(75, 23);
            this.ellipseButton.TabIndex = 4;
            this.ellipseButton.Text = "ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // constrainRectangleProportionsCheckbox
            // 
            this.constrainRectangleProportionsCheckbox.AutoSize = true;
            this.constrainRectangleProportionsCheckbox.Location = new System.Drawing.Point(825, 78);
            this.constrainRectangleProportionsCheckbox.Name = "constrainRectangleProportionsCheckbox";
            this.constrainRectangleProportionsCheckbox.Size = new System.Drawing.Size(124, 17);
            this.constrainRectangleProportionsCheckbox.TabIndex = 5;
            this.constrainRectangleProportionsCheckbox.Text = "constrain proportions";
            this.constrainRectangleProportionsCheckbox.UseVisualStyleBackColor = true;
            this.constrainRectangleProportionsCheckbox.CheckedChanged += new System.EventHandler(this.constrainRectangleProportionsCheckbox_CheckedChanged);
            // 
            // constrainEllipseProportionsCheckbox
            // 
            this.constrainEllipseProportionsCheckbox.AutoSize = true;
            this.constrainEllipseProportionsCheckbox.Location = new System.Drawing.Point(825, 105);
            this.constrainEllipseProportionsCheckbox.Name = "constrainEllipseProportionsCheckbox";
            this.constrainEllipseProportionsCheckbox.Size = new System.Drawing.Size(124, 17);
            this.constrainEllipseProportionsCheckbox.TabIndex = 6;
            this.constrainEllipseProportionsCheckbox.Text = "constrain proportions";
            this.constrainEllipseProportionsCheckbox.UseVisualStyleBackColor = true;
            this.constrainEllipseProportionsCheckbox.CheckedChanged += new System.EventHandler(this.constrainEllipseProportionsCheckbox_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(743, 275);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 309);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // layerCombobox
            // 
            this.layerCombobox.FormattingEnabled = true;
            this.layerCombobox.Location = new System.Drawing.Point(742, 248);
            this.layerCombobox.Name = "layerCombobox";
            this.layerCombobox.Size = new System.Drawing.Size(199, 21);
            this.layerCombobox.TabIndex = 8;
            this.layerCombobox.SelectedIndexChanged += new System.EventHandler(this.layerCombobox_SelectedIndexChanged);
            // 
            // addLayerButton
            // 
            this.addLayerButton.Location = new System.Drawing.Point(742, 219);
            this.addLayerButton.Name = "addLayerButton";
            this.addLayerButton.Size = new System.Drawing.Size(61, 23);
            this.addLayerButton.TabIndex = 9;
            this.addLayerButton.Text = "add layer";
            this.addLayerButton.UseVisualStyleBackColor = true;
            this.addLayerButton.Click += new System.EventHandler(this.addLayerButton_Click);
            // 
            // addLayerTextbox
            // 
            this.addLayerTextbox.Location = new System.Drawing.Point(808, 222);
            this.addLayerTextbox.Name = "addLayerTextbox";
            this.addLayerTextbox.Size = new System.Drawing.Size(133, 20);
            this.addLayerTextbox.TabIndex = 10;
            // 
            // colourButton
            // 
            this.colourButton.Location = new System.Drawing.Point(781, 193);
            this.colourButton.Name = "colourButton";
            this.colourButton.Size = new System.Drawing.Size(22, 23);
            this.colourButton.TabIndex = 11;
            this.colourButton.UseVisualStyleBackColor = true;
            this.colourButton.Click += new System.EventHandler(this.colourButton1_Click);
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(725, 572);
            this.canvas.TabIndex = 13;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // polygonButton
            // 
            this.polygonButton.Location = new System.Drawing.Point(745, 130);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(73, 23);
            this.polygonButton.TabIndex = 14;
            this.polygonButton.Text = "polygon";
            this.polygonButton.UseVisualStyleBackColor = true;
            this.polygonButton.Click += new System.EventHandler(this.polygonButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(825, 171);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 15;
            // 
            // brushWidthSlider
            // 
            this.brushWidthSlider.AutoSize = true;
            this.brushWidthSlider.Location = new System.Drawing.Point(847, 203);
            this.brushWidthSlider.Name = "brushWidthSlider";
            this.brushWidthSlider.Size = new System.Drawing.Size(61, 13);
            this.brushWidthSlider.TabIndex = 16;
            this.brushWidthSlider.Text = "brush width";
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(833, 13);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 17;
            this.moveButton.Text = "move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(956, 596);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.brushWidthSlider);
            this.Controls.Add(this.polygonButton);
            this.Controls.Add(this.canvas);
            this.Controls.Add(selectedColourLabel);
            this.Controls.Add(this.colourButton);
            this.Controls.Add(this.addLayerTextbox);
            this.Controls.Add(this.addLayerButton);
            this.Controls.Add(this.layerCombobox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.constrainEllipseProportionsCheckbox);
            this.Controls.Add(this.constrainRectangleProportionsCheckbox);
            this.Controls.Add(this.ellipseButton);
            this.Controls.Add(this.rectangleButton);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.freehandButton);
            this.Controls.Add(this.trackBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "View";
            this.Text = "Drawing App";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button freehandButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.CheckBox constrainRectangleProportionsCheckbox;
        private System.Windows.Forms.CheckBox constrainEllipseProportionsCheckbox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox layerCombobox;
        private System.Windows.Forms.Button addLayerButton;
        private System.Windows.Forms.TextBox addLayerTextbox;
        private System.Windows.Forms.Button colourButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button polygonButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label brushWidthSlider;
        private System.Windows.Forms.Button moveButton;
    }
}

