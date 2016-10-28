using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Calculating hash and submitting form after the send button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string formScript = "<script language=\"javascript\" type=\"text/javascript\">" +
                            "document.getElementById('{0}').submit();" +
                            "</script>";

        string formName = "form1";
        string formAction = "https://test.ipg-online.com/connect/gateway/processing";

        //if timezone isn't specified, will get local timezone and put it into textbox in the web form
        if (this.timezone.Text.Equals(String.Empty))
        {
            String[] TimeZoneDispNameSplit = TimeZoneInfo.Local.DisplayName.Split(' ');
            this.timezone.Text = Regex.Replace(TimeZoneDispNameSplit[0], @"[)(]", String.Empty); ;
        }

        //if date and time isn't specified, will get actual date and time and put it into textbox in the web form
        if (this.txndatetime.Text.Equals(String.Empty))
            this.txndatetime.Text = DateTime.Now.ToString(@"yyyy\:MM\:dd-HH\:mm\:ss");

        //hash
        var StringToHash = this.storename.Text + this.txndatetime.Text + this.chargetotal.Text + this.currency.Text + this.sharedsecret.Text;

        //calculate hash value and put it into textbox in the web form
        string hash = CalculateHash.calculateHashFromString(new StringBuilder(StringToHash), this.hash_algorithm.Text);
        this.hash.Text = hash;

        ltrForm.Text = string.Format("<form id=\"{0}\" name=\"{0}\" method=\"post\" action=\"{1}\">", formName, formAction) + AllInputTagsString() + "</form>";
        ltrScript.Text = string.Format(formScript, formName);

    }

    /// <summary>
    /// Creates input tags of the send form with id and values from fields in the web form
    /// </summary>
    /// <returns>string containing all input tags</returns>
    protected string AllInputTagsString()
    {
        StringBuilder result = new StringBuilder();
        string input = "<input type=\"hidden\" name=\"{0}\" value=\"{1}\"/>";

        foreach (Control control in form.Controls)
        {
            string controlName = control.GetType().Name;

            if (!(controlName.Equals("LiteralControl") || controlName.Equals("CheckBox") || controlName.Equals("Button")))
            {
                var textProperty = control.GetType().GetProperty("Text");

                if (textProperty != null)
                {
                    var text = textProperty.GetGetMethod().Invoke(control, null);
                    result.Append(string.Format(input, control.ID, text));
                }
            }
        }
        return result.ToString();
    }
}