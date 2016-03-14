namespace HciDrawingProgram
{
    partial class Form1
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
            this.panel = new System.Windows.Forms.Panel();
            this.freehandButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.constrainRectangleProportionsCheckbox = new System.Windows.Forms.CheckBox();
            this.constrainEllipseProportionsCheckbox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.addLayerButton = new System.Windows.Forms.Button();
            this.addLayerTextbox = new System.Windows.Forms.TextBox();
            this.colourButton1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            selectedColourLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(853, 155);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(38, 35);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(742, 248);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            // colourButton1
            // 
            this.colourButton1.Location = new System.Drawing.Point(785, 193);
            this.colourButton1.Name = "colourButton1";
            this.colourButton1.Size = new System.Drawing.Size(18, 23);
            this.colourButton1.TabIndex = 11;
            this.colourButton1.UseVisualStyleBackColor = true;
            this.colourButton1.Click += new System.EventHandler(this.colourButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(725, 572);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 596);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(selectedColourLabel);
            this.Controls.Add(this.colourButton1);
            this.Controls.Add(this.addLayerTextbox);
            this.Controls.Add(this.addLayerButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.constrainEllipseProportionsCheckbox);
            this.Controls.Add(this.constrainRectangleProportionsCheckbox);
            this.Controls.Add(this.ellipseButton);
            this.Controls.Add(this.rectangleButton);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.freehandButton);
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button freehandButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.CheckBox constrainRectangleProportionsCheckbox;
        private System.Windows.Forms.CheckBox constrainEllipseProportionsCheckbox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button addLayerButton;
        private System.Windows.Forms.TextBox addLayerTextbox;
        private System.Windows.Forms.Button colourButton1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

