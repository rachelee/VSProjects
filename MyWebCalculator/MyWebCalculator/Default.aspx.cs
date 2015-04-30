using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebCalculator
{
    public partial class _Default : Page
    {
        static Double resVal = 0;
        static String operation = "";
        static Boolean isOperationPerformed = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonClick(object sender, EventArgs e)
        {
            if (Result.Text == "0" || isOperationPerformed == true)
                Result.Text = String.Empty;
            isOperationPerformed = false;
            Button button = (Button)sender;
            Result.Text = Result.Text + button.Text;
        }

        protected void pointClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!Result.Text.Contains("."))
                Result.Text = Result.Text + button.Text;
        }

        protected void operatorClick(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            operation = button.Text;
            //if there is text in the result.Text window, Format exception will happen, handle it
            try
            {
                resVal = Double.Parse(Result.Text);
            }
            catch (FormatException)
            {
                Result.Text = "0";
                resVal = 0;
            }
            Label_Op.Text = resVal + " " + operation;
            isOperationPerformed = true;

        }

        protected void EqualTo_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    Result.Text = (resVal + Double.Parse(Result.Text)).ToString();
                    break;
                case "-":
                    Result.Text = (resVal - Double.Parse(Result.Text)).ToString();
                    break;
                case "*":
                    Result.Text = (resVal * Double.Parse(Result.Text)).ToString();
                    break;
                case "/":
                    if (Result.Text == "0")
                    {
                        Result.Text = "Cannot be divided by Zero";
                        resVal = 0;
                        break;
                    }
                    Result.Text = (resVal / Double.Parse(Result.Text)).ToString();
                    break;
                default:
                    break;
            }

            Label_Op.Text = "";
            resVal = 0;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
            resVal = 0;
            Label_Op.Text = "";

        }

        protected void ClearEntry_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
        }

        protected void Sin_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Result.Text = Convert.ToString(System.Math.Sin((Convert.ToDouble(System.Math.PI) / 180) *
                (Convert.ToDouble(Result.Text))));

        }

        protected void Cos_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Result.Text = Convert.ToString(System.Math.Cos((Convert.ToDouble(System.Math.PI) / 180) *
                (Convert.ToDouble(Result.Text))));

        }

        protected void Tan_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Result.Text = Convert.ToString(System.Math.Tan((Convert.ToDouble(System.Math.PI) / 180) *
                (Convert.ToDouble(Result.Text))));

        }

        protected void X2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            try
            {
                int square = (int)(Convert.ToInt32(Result.Text) * Convert.ToInt32(Result.Text));
                Result.Text = Convert.ToString(square);
            }
            catch (OverflowException)
            {
                Result.Text = "Result overflow";
            }

        }

        protected void X3_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            try
            {
                Result.Text = Convert.ToString(System.Math.Pow(Convert.ToDouble(Result.Text), 3));
            }
            catch (FormatException)
            {
                Result.Text = "0";
            }

        }

        protected void Reciprocal_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Result.Text = Convert.ToString(1 / Convert.ToDouble(Result.Text));

        }

        protected void Pi_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Result.Text = Convert.ToString(Math.PI);

        }

        protected void Sqrt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Result.Text.Contains("-"))
            {
                //if the number is negative, throw a InvalidOperationException and handle it
                try
                {
                    throw new System.InvalidOperationException("Cannot get the square root of a negative number");
                }
                catch (InvalidOperationException)
                {
                    Result.Text = "Invalid operation";
                }

            }
            else
                Result.Text = Convert.ToString(System.Math.Sqrt(Convert.ToDouble(Result.Text)));

        }

        protected void Log_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Result.Text == "0")
            {
                //if the number is 0, throw a NotFiniteNumberException and handle it
                try
                {
                    throw new System.NotFiniteNumberException("Cannot calculate the log of zero");
                }
                catch (NotFiniteNumberException)
                {
                    Result.Text = "Cannot calculate the log of zero";
                }
            }
            else if (Result.Text.Contains("-"))
            {
                //if the number is negative, throw a ArithmeticException and handle it
                try
                {
                    throw new System.ArithmeticException("Cannot calculate the log of negative number");
                }
                catch (ArithmeticException)
                {
                    Result.Text = "Cannot calculate the log of negative number";
                }
            }
            else
                Result.Text = Convert.ToString(System.Math.Log(Convert.ToDouble(Result.Text)));

        }

        protected void Backspace_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //Backspace function is not implemented so throw exception and handle it
            try
            {
                throw new System.NotImplementedException("Backspace function has not been implemented");
            }
            catch (NotImplementedException)
            {
                Result.Text = "Function Not Implemented";
            }

        }








        
    }
}