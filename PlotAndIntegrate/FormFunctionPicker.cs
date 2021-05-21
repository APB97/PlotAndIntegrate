using APB97.Math;
using System;
using System.Windows.Forms;

namespace PlotAndIntegrate
{
    public partial class FormFunctionPicker : Form
    {
        public IFunction SelectedFunction { get; private set; }

        public FormFunctionPicker()
        {
            InitializeComponent();
        }

        private void FormFunctionPicker_Load(object sender, EventArgs e)
        {
            comboBoxType.Items.Add(new PolynomialFunction(0));
            comboBoxType.Items.Add(new LogarithmicFunction(2));
            comboBoxType.SelectedIndex = 0;
        }

        private void ButtonCreateNew_Click(object sender, EventArgs e)
        {
            var pickedType = comboBoxType.SelectedItem as IFunction;
            IFunction function = (IFunction)pickedType.Clone();
            SelectedFunction = function;
        }

        private void TextBoxParameters_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxParameters.Text))
                return;
            string[] splitBySpace = textBoxParameters.Text.Split(' ');
            IFunction function = comboBoxType.SelectedItem as IFunction;
            if (!function.TryPassParameters(splitBySpace))
                e.Cancel = true;
        }

        private void ComboBoxType_SelectedValueChanged(object sender, EventArgs e)
        {
            System.ComponentModel.CancelEventArgs cea = new();
            TextBoxParameters_Validating(sender, cea);
            if (cea.Cancel)
                MessageBox.Show("Paramters mismatch. Try entering parameters again.");
        }
    }
}
