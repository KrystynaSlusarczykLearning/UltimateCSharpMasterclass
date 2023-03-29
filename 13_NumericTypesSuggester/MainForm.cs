using System.Numerics;

namespace NumericTypesSuggester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void IntegralOnlyCheckBox_CheckedChanged(
            object sender, EventArgs e)
        {
            MustBePreciseCheckbox.Visible =
                !IntegralOnlyCheckBox.Checked;

            RecalculateSuggestedType();
        }

        private void MustBePreciseCheckbox_CheckedChanged(
            object sender, EventArgs e)
        {
            RecalculateSuggestedType();
        }

        private void TextBox_TextChanged(
            object sender, EventArgs e)
        {
            RecalculateSuggestedType();
            SetColorOfMaxValueTextField();
        }

        private void TextBox_KeyPress(
            object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            if(!IsValidInput(e.KeyChar, textBox))
            {
                e.Handled = true;
            }
        }

        private static bool IsValidInput(
            char keyChar, TextBox textBox)
        {
            return 
                char.IsControl(keyChar) ||
                char.IsDigit(keyChar) ||
                (keyChar == '-' && textBox.SelectionStart == 0);
        }

        private void SetColorOfMaxValueTextField()
        {
            bool isValid = true;

            if(IsInputComplete())
            {
                var minValue = BigInteger.Parse(
                    MinValueTextBox.Text);
                var maxValue = BigInteger.Parse(
                    MaxValueTextBox.Text);

                if(maxValue < minValue)
                {
                    isValid = false;
                }
            }

            MaxValueTextBox.BackColor =
                isValid ? Color.White : Color.IndianRed;
        }

        private bool IsInputComplete()
        {
            return
                MinValueTextBox.Text.Length > 0 &&
                MinValueTextBox.Text != "-" &&
                MaxValueTextBox.Text.Length > 0 &&
                MaxValueTextBox.Text != "-";
        }

        private void RecalculateSuggestedType()
        {
            if(IsInputComplete())
            {
                var minValue = BigInteger.Parse(
                    MinValueTextBox.Text);
                var maxValue = BigInteger.Parse(
                    MaxValueTextBox.Text);

                if(maxValue >= minValue)
                {
                    SuggestedTypeResult.Text =
                        NumericTypeSuggester.GetName(
                            minValue,
                            maxValue,
                            IntegralOnlyCheckBox.Checked,
                            MustBePreciseCheckbox.Checked);
                    return;
                }
            }
            SuggestedTypeResult.Text = "not enough data";
        }
    }
}