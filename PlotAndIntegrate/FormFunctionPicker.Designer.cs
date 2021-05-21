
namespace PlotAndIntegrate
{
    partial class FormFunctionPicker
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
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonCreateNew = new System.Windows.Forms.Button();
            this.textBoxParameters = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(12, 27);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(209, 23);
            this.comboBoxType.TabIndex = 0;
            this.comboBoxType.SelectedValueChanged += new System.EventHandler(this.ComboBoxType_SelectedValueChanged);
            // 
            // buttonCreateNew
            // 
            this.buttonCreateNew.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCreateNew.Location = new System.Drawing.Point(12, 100);
            this.buttonCreateNew.Name = "buttonCreateNew";
            this.buttonCreateNew.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateNew.TabIndex = 1;
            this.buttonCreateNew.Text = "Create new";
            this.buttonCreateNew.UseVisualStyleBackColor = true;
            this.buttonCreateNew.Click += new System.EventHandler(this.ButtonCreateNew_Click);
            // 
            // textBoxParameters
            // 
            this.textBoxParameters.Location = new System.Drawing.Point(12, 71);
            this.textBoxParameters.Name = "textBoxParameters";
            this.textBoxParameters.Size = new System.Drawing.Size(209, 23);
            this.textBoxParameters.TabIndex = 2;
            this.textBoxParameters.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxParameters_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parameters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Function type";
            // 
            // FormFunctionPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 393);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxParameters);
            this.Controls.Add(this.buttonCreateNew);
            this.Controls.Add(this.comboBoxType);
            this.Name = "FormFunctionPicker";
            this.Text = "FormFunctionPicker";
            this.Load += new System.EventHandler(this.FormFunctionPicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Button buttonCreateNew;
        private System.Windows.Forms.TextBox textBoxParameters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}