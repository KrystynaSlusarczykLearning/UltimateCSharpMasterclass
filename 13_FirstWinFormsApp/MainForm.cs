namespace FirstWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private int _count = 0;
        private void IncreaseCounterButton_Click(
            object sender, EventArgs e)
        {
            _count++;
            CounterLabel.Text = _count.ToString();
        }

        private void HideButtonCheckbox_CheckedChanged(
            object sender, EventArgs e)
        {
            IncreaseCounterButton.Visible =
                !IncreaseCounterButton.Visible;

            bool isChecked = HideButtonCheckbox.Checked;
        }

        private void YearOfBirthTextBox_KeyPress(
            object sender, KeyPressEventArgs e)
        {
            if(!IsValid(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool IsValid(char keyChar)
        {
            return char.IsControl(keyChar) ||
                (char.IsDigit(keyChar) &&
                 YearOfBirthTextBox.Text.Length < 4);
        }
    }
}