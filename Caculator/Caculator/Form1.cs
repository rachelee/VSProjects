using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caculator
{
    public partial class Form1 : Form
    {
        Double resVal = 0;
        String operation = "";
        Boolean isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (result.Text == "0" || (result.Text =="Cannot be divided by Zero") || (isOperationPerformed))
                result.Clear();
            isOperationPerformed = false;
            Button button = (Button)sender;
            
            if(button.Text == ".")
            {
                if (!result.Text.Contains("."))
                    result.Text = result.Text + button.Text;
            }
            else
                result.Text = result.Text + button.Text;
        }

        private void operatorClick(object sender, EventArgs e)
        {
            if(resVal != 0)
            {
                equalTo.PerformClick();
            }
            if (result.Text !="Cannot be divided by Zero")
            {
                Button button = (Button)sender;
                operation = button.Text;
                resVal = Double.Parse(result.Text);
                LabelCurrentOp.Text = resVal + " " + operation;
                isOperationPerformed = true;
            }
            
        }

        private void clearClick(object sender, EventArgs e)
        {
            result.Text = "0";
            resVal = 0;
            LabelCurrentOp.Text = "";
            
        }

        private void clearEntryClick(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void equalToClick(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    result.Text = (resVal + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (resVal - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (resVal * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    //if a number is divided by zero, the DivideByZeroException will 
                    //occur and the text box will display "Cannot be divided by zero"
                    try
                    {
                        if (result.Text == "0")
                        {
                            int y = int.Parse(result.Text);
                            int x = (int)resVal;
                            result.Text = (x / y).ToString();
                        }
                        else
                            result.Text = (resVal / Double.Parse(result.Text)).ToString();
                    }
                    catch(DivideByZeroException)
                    {
                        result.Text = "Cannot be divided by Zero";
                        resVal = 0;
                    }
                    break;
                default:
                    break;
            }

            LabelCurrentOp.Text = "";
            resVal = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (result.Text == "0" || (result.Text == "Cannot be divided by Zero") || (isOperationPerformed))
                result.Clear();
            
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad. 
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace. 
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed. 
                        // Set the flag to true and evaluate in KeyPress event.
                        if (result.Text == "0" || (result.Text == "Cannot be divided by Zero") || (isOperationPerformed))
                            result.Clear();
                        isOperationPerformed = false;
                        result.Text = result.Text + e.KeyValue;
                        
                    }
                }
            }
        }


    }
}
