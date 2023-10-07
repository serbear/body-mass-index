using System;
using System.Windows.Forms;

namespace body_mass_index
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        public static string CalculateBmi(TextBox w, TextBox h)
        {
            const float poundToKilo = 0.453592f;
            const float inchesToMeter = 0.0254f;
            var weightValue = GetTextBoxValue(w) * poundToKilo;
            var heightValue = GetTextBoxValue(h) * inchesToMeter;
            var bmiValue = weightValue / (heightValue * heightValue);
            return GetAnswer(bmiValue);
        }

        private static string GetAnswer(float bmi)
        {
            var output = "BMI: " + Math.Round(bmi, 2) + Environment.NewLine;
            return output + "Status: " + GetBmiStatus(bmi);
        }

        private static string GetBmiStatus(float bmi)
        {
            var status = "";
            switch (bmi)
            {
                case float n when n < 16:
                    status = "Severe Thinness";
                    break;
                case float n when n >= 16 && n < 17:
                    status = "Moderate Thinness";
                    break;
                case float n when n >= 17 && n < 18.5:
                    status = "Mild Thinness";
                    break;
                case float n when n >= 18.5 && n < 25:
                    status = "Normal";
                    break;
                case float n when n >= 25 && n < 30:
                    status = "Overweight";
                    break;
                case float n when n >= 30 && n < 35:
                    status = "Obese Class I";
                    break;
                case float n when n >= 35 && n < 40:
                    status = "Obese Class II";
                    break;
                case float n when n > 40:
                    status = "Obese Class III";
                    break;
            }

            return status;
        }

        private static float GetTextBoxValue(object sender)
        {
            var tb = (TextBox)sender;
            var value = tb.Text.Replace(".", ",");
            var isOk = float.TryParse(value, out var output);

            if (isOk && !value.Equals(""))
            {
                return output;
            }

            throw new InvalidTextBoxValueException(tb);
        }
    }

    public class InvalidTextBoxValueException : Exception
    {
        public InvalidTextBoxValueException(TextBox tb) : base(
            "Invalid value in field '" + tb.Tag + "'")
        {
            TargetTextBox = tb;
        }

        public TextBox TargetTextBox { get; }
    }
}