
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
            this.numericFontSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonIntegrate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericPlotWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonPlotColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlotWidth)).BeginInit();
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
            this.pictureBoxPlot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxPlot_MouseDown);
            this.pictureBoxPlot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxPlot_MouseMove);
            this.pictureBoxPlot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxPlot_MouseUp);
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
            // numericFontSize
            // 
            this.numericFontSize.Location = new System.Drawing.Point(327, 12);
            this.numericFontSize.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numericFontSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericFontSize.Name = "numericFontSize";
            this.numericFontSize.Size = new System.Drawing.Size(46, 23);
            this.numericFontSize.TabIndex = 6;
            this.numericFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericFontSize.ValueChanged += new System.EventHandler(this.NumericFontSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Font size";
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Location = new System.Drawing.Point(12, 383);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.ReadOnly = true;
            this.textBoxFunction.Size = new System.Drawing.Size(250, 23);
            this.textBoxFunction.TabIndex = 8;
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(161, 16);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(83, 23);
            this.textBoxTo.TabIndex = 9;
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(48, 16);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(80, 23);
            this.textBoxFrom.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxResult);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonIntegrate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxTo);
            this.groupBox1.Controls.Add(this.textBoxFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 412);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 106);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Integrate";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(56, 75);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(188, 23);
            this.textBoxResult.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Result:";
            // 
            // buttonIntegrate
            // 
            this.buttonIntegrate.Location = new System.Drawing.Point(6, 45);
            this.buttonIntegrate.Name = "buttonIntegrate";
            this.buttonIntegrate.Size = new System.Drawing.Size(238, 23);
            this.buttonIntegrate.TabIndex = 11;
            this.buttonIntegrate.Text = "Integrate";
            this.buttonIntegrate.UseVisualStyleBackColor = true;
            this.buttonIntegrate.Click += new System.EventHandler(this.ButtonIntegrate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "to:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "from:";
            // 
            // numericPlotWidth
            // 
            this.numericPlotWidth.Location = new System.Drawing.Point(327, 41);
            this.numericPlotWidth.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericPlotWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPlotWidth.Name = "numericPlotWidth";
            this.numericPlotWidth.Size = new System.Drawing.Size(46, 23);
            this.numericPlotWidth.TabIndex = 12;
            this.numericPlotWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericPlotWidth.ValueChanged += new System.EventHandler(this.NumericPlotWidth_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Plot size";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Plot color";
            // 
            // buttonPlotColor
            // 
            this.buttonPlotColor.BackColor = System.Drawing.Color.Blue;
            this.buttonPlotColor.Location = new System.Drawing.Point(327, 70);
            this.buttonPlotColor.Name = "buttonPlotColor";
            this.buttonPlotColor.Size = new System.Drawing.Size(46, 23);
            this.buttonPlotColor.TabIndex = 15;
            this.buttonPlotColor.UseVisualStyleBackColor = false;
            this.buttonPlotColor.Click += new System.EventHandler(this.ButtonPlotColor_Click);
            // 
            // FormPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.buttonPlotColor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericPlotWidth);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxFunction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericFontSize);
            this.Controls.Add(this.buttonPickNewOne);
            this.Controls.Add(this.buttonSaveAsImage);
            this.Controls.Add(this.textBoxUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCoordinates);
            this.Controls.Add(this.pictureBoxPlot);
            this.Name = "FormPlot";
            this.Text = "Plot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPlot_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlotWidth)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numericFontSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonIntegrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.NumericUpDown numericPlotWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonPlotColor;
    }
}

