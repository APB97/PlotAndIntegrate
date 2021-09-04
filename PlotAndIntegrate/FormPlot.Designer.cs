
namespace PlotAndIntegrate
{
    partial class FormPlot
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxPlot = new System.Windows.Forms.PictureBox();
            this.textBoxCoordinates = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.buttonSaveAsImage = new System.Windows.Forms.Button();
            this.buttonPickNewOne = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPlot
            // 
            this.pictureBoxPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPlot.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxPlot.Name = "pictureBoxPlot";
            this.pictureBoxPlot.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxPlot.TabIndex = 0;
            this.pictureBoxPlot.TabStop = false;
            this.pictureBoxPlot.SizeChanged += new System.EventHandler(this.PictureBoxPlot_SizeChanged);
            this.pictureBoxPlot.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxPlot_Paint);
            this.pictureBoxPlot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxPlot_MouseMove);
            // 
            // textBoxCoordinates
            // 
            this.textBoxCoordinates.Location = new System.Drawing.Point(12, 269);
            this.textBoxCoordinates.Name = "textBoxCoordinates";
            this.textBoxCoordinates.ReadOnly = true;
            this.textBoxCoordinates.Size = new System.Drawing.Size(250, 23);
            this.textBoxCoordinates.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unit";
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(47, 296);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(215, 23);
            this.textBoxUnit.TabIndex = 3;
            this.textBoxUnit.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxUnit_Validating);
            this.textBoxUnit.Validated += new System.EventHandler(this.TextBoxUnit_Validated);
            // 
            // buttonSaveAsImage
            // 
            this.buttonSaveAsImage.Location = new System.Drawing.Point(12, 325);
            this.buttonSaveAsImage.Name = "buttonSaveAsImage";
            this.buttonSaveAsImage.Size = new System.Drawing.Size(250, 23);
            this.buttonSaveAsImage.TabIndex = 4;
            this.buttonSaveAsImage.Text = "Save as image...";
            this.buttonSaveAsImage.UseVisualStyleBackColor = true;
            this.buttonSaveAsImage.Click += new System.EventHandler(this.ButtonSaveAsImage_Click);
            // 
            // buttonPickNewOne
            // 
            this.buttonPickNewOne.Location = new System.Drawing.Point(12, 354);
            this.buttonPickNewOne.Name = "buttonPickNewOne";
            this.buttonPickNewOne.Size = new System.Drawing.Size(250, 23);
            this.buttonPickNewOne.TabIndex = 5;
            this.buttonPickNewOne.Text = "Pick new function";
            this.buttonPickNewOne.UseVisualStyleBackColor = true;
            this.buttonPickNewOne.Click += new System.EventHandler(this.ButtonPickNewOne_Click);
            // 
            // FormPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPickNewOne);
            this.Controls.Add(this.buttonSaveAsImage);
            this.Controls.Add(this.textBoxUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCoordinates);
            this.Controls.Add(this.pictureBoxPlot);
            this.Name = "FormPlot";
            this.Text = "Plot";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPlot;
        private System.Windows.Forms.TextBox textBoxCoordinates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.Button buttonSaveAsImage;
        private System.Windows.Forms.Button buttonPickNewOne;
    }
}

