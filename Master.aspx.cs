using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebBasedTechnologies_HW1
{
    public partial class Master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static bool checkLuhn(String cardNo)
        {
            int nDigits = cardNo.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {

                int d = cardNo[i] - '0';

                if (isSecond == true)
                    d = d * 2;

                // We add two digits to handle
                // cases that make two digits
                // after doubling
                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long CardNumber = long.Parse(TextBox1.Text);
            if (Regex.IsMatch(CardNumber.ToString(), @"^(5018|5020|5038|6304|6759|6761|6763)[0-9]{8,15}$"))
            {
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = false;
                Image4.Visible = true;
                Image5.Visible = false;
            }
            //visa card
            else if(Regex.IsMatch(CardNumber.ToString(), @"^4[0-9]{12}(?:[0-9]{3})?$"))
            {
                Image1.Visible = true;
                Image2.Visible = false;
                Image3.Visible = false;
                Image4.Visible = false;
                Image5.Visible = false;
            }
            //mastercard
            else if (Regex.IsMatch(CardNumber.ToString(), @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$"))
            {
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = true;
                Image4.Visible = false;
                Image5.Visible = false;
            }
            else if (Regex.IsMatch(CardNumber.ToString(), @"^6(?:011|5[0-9]{2})[0-9]{12}$"))
            {
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = false;
                Image4.Visible = false;
                Image5.Visible = true;
            }
            else if (Regex.IsMatch(CardNumber.ToString(), @"^3[47][0-9]{13}$"))
            {
                Image1.Visible = false;
                Image2.Visible = true;
                Image3.Visible = false;
                Image4.Visible = false;
                Image5.Visible = false;
            }
            else
            {
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = false;
                Image4.Visible = false;
                Image5.Visible = false;
                TextBox1.Text = "Unknown card type";
            }
            if (checkLuhn(TextBox1.Text))
            {
                lblluhn.Text = ("This is a valid card");
                lblluhn.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblluhn.Text = ("This is not a valid card");
                lblluhn.ForeColor = System.Drawing.Color.Red;
            }
                
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}