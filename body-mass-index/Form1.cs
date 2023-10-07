using System;
using System.Windows.Forms;

namespace body_mass_index
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var answer =""; 
            try
            {
                answer = Program.CalculateBmi(tbWeight, tbHeight);
            }
            catch (InvalidTextBoxValueException invalidTextBoxValueException)
            {
                MessageBox.Show(invalidTextBoxValueException.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                invalidTextBoxValueException.TargetTextBox.SelectAll();
                invalidTextBoxValueException.TargetTextBox.Focus();
            }
            finally
            {
                tbAnswer.Text = answer;
            }
            
        }
    }
}