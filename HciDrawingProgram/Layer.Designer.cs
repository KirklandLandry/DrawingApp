namespace HciDrawingProgram
{
    partial class Layer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.visibleCheckBox = new System.Windows.Forms.CheckBox();
            this.currentLayerCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.deleteLayerButton = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // visibleCheckBox
            // 
            this.visibleCheckBox.AutoSize = true;
            this.visibleCheckBox.Location = new System.Drawing.Point(6, 39);
            this.visibleCheckBox.Name = "visibleCheckBox";
            this.visibleCheckBox.Size = new System.Drawing.Size(56, 17);
            this.visibleCheckBox.TabIndex = 1;
            this.visibleCheckBox.Text = "Visible";
            this.visibleCheckBox.UseVisualStyleBackColor = true;
            this.visibleCheckBox.CheckedChanged += new System.EventHandler(this.visibleCheckBox_CheckedChanged);
            // 
            // currentLayerCheckBox
            // 
            this.currentLayerCheckBox.AutoSize = true;
            this.currentLayerCheckBox.Enabled = false;
            this.currentLayerCheckBox.Location = new System.Drawing.Point(6, 16);
            this.currentLayerCheckBox.Name = "currentLayerCheckBox";
            this.currentLayerCheckBox.Size = new System.Drawing.Size(89, 17);
            this.currentLayerCheckBox.TabIndex = 2;
            this.currentLayerCheckBox.Text = "Current Layer";
            this.currentLayerCheckBox.UseVisualStyleBackColor = true;
            this.currentLayerCheckBox.CheckedChanged += new System.EventHandler(this.currentLayerCheckBox_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.deleteLayerButton);
            this.groupBox.Controls.Add(this.visibleCheckBox);
            this.groupBox.Controls.Add(this.currentLayerCheckBox);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(180, 65);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // deleteLayerButton
            // 
            this.deleteLayerButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteLayerButton.Location = new System.Drawing.Point(125, 16);
            this.deleteLayerButton.Name = "deleteLayerButton";
            this.deleteLayerButton.Size = new System.Drawing.Size(49, 40);
            this.deleteLayerButton.TabIndex = 3;
            this.deleteLayerButton.Text = "Delete Layer";
            this.deleteLayerButton.UseVisualStyleBackColor = false;
            this.deleteLayerButton.Click += new System.EventHandler(this.deleteLayerButton_Click);
            // 
            // Layer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label1);
            this.Name = "Layer";
            this.Size = new System.Drawing.Size(186, 76);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox visibleCheckBox;
        private System.Windows.Forms.CheckBox currentLayerCheckBox;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button deleteLayerButton;
    }
}
