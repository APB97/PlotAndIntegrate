using APB97.Features;
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
            if (FeatureManager.IsEnabled(FeaturesList.FunctionsFactory))
            {
                comboBoxType.Items.Add(new Factory<IFunction>(() => new PolynomialFunction(),"Polynomial Function (takes any number of float parameters)"));
                comboBoxType.Items.Add(new Factory<IFunction>(() => new LogarithmicFunction(), "Logarithmic Function (takes one positive argument not equal to 1)"));
            }
            else
            {
                comboBoxType.Items.Add(new PolynomialFunction(0));
                comboBoxType.Items.Add(new LogarithmicFunction(2));
            }
            comboBoxType.SelectedIndex = 0;
        }

        private void ButtonCreateNew_Click(object sender, EventArgs e)
        {
            if (!FeatureManager.IsEnabled(FeaturesList.FunctionsFactory))
            {
                var pickedType = comboBoxType.SelectedItem as IFunction;
                IFunction function = (IFunction)pickedType.Clone();
                SelectedFunction = function;
            }
        }

        private void TextBoxParameters_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (comboBoxType.SelectedItem == null || string.IsNullOrEmpty(textBoxParameters.Text))
                return;
            string[] splitBySpace = textBoxParameters.Text.Split(' ');
            if (!SelectedFunction.TryPassParameters(splitBySpace))
                e.Cancel = true;
        }

        private void ComboBoxType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FeatureManager.IsEnabled(FeaturesList.FunctionsFactory))
            {
                SelectedFunction = (comboBoxType.SelectedItem as Factory<IFunction>).CreateNew();
            }
            System.ComponentModel.CancelEventArgs cea = new();
            TextBoxParameters_Validating(sender, cea);
            if (cea.Cancel)
                MessageBox.Show("Paramters mismatch. Try entering parameters again.");
        }
    }
}
