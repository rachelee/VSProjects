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
        Double resVal = 0;
        String operation = "";
        Boolean isOperationPerformed = false;

        //TextBox Result = Control.FindControl("Result") as TextBox;


        //protected System.Web.UI.WebControls.TextBox Result;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void buttonClick(object sender, EventArgs e)
        {
            if (Result.Text == "0" || isOperationPerformed)
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

        protected void Sin_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Result.Text = Convert.ToString(System.Math.Sin((Convert.ToDouble(System.Math.PI) / 180) *
                (Convert.ToDouble(Result.Text))));

        }
    }
}