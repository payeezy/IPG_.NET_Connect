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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Calculating extended hash and submitting form after the send button is clicked
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

        //get dictionary containing all fields from web form (ID,value)
        var allComponents = GetAllFormComponents();

        //calcualte extended hash from sorted web form fields and update hashExtended value in web form and dictionary
        string hashExtended = CalculateHash.calculateHashFromString(new StringBuilder(StringToHashExtended(allComponents)), this.hash_algorithm.Text);
        this.hashExtended.Text = hashExtended;
        allComponents["hashExtended"] = hashExtended;

        ltrForm.Text = string.Format("<form id=\"{0}\" name=\"{0}\" method=\"post\" action=\"{1}\">", formName, formAction) + AllInputTagstring(allComponents) + "</form>";
        ltrScript.Text = string.Format(formScript, formName);
    }

    /// <summary>
    /// Takes all fields from web form and puts their ID and text value into a sorted dictionary
    /// </summary>
    /// <returns>dictionary containing fields from web form. Key is their ID and VAlue is their text value</returns>
    protected SortedDictionary<string, string> GetAllFormComponents()
    {
        var allFormComponents = new SortedDictionary<string, string>();

        foreach (Control control in form.Controls)
        {
            var controlName = control.GetType().Name;

            if (!(controlName.Equals("LiteralControl") || controlName.Equals("CheckBox") || controlName.Equals("Button")))
            {
                var textProperty = control.GetType().GetProperty("Text");

                if (textProperty != null)
                {
                    var text = textProperty.GetGetMethod().Invoke(control, null);
                    allFormComponents.Add(control.ID, (string)text);
                }
            }
        }

        return allFormComponents;
    }

    /// <summary>
    /// Creates string form all web form fields. Values are taken from sorted dictionaty (sorted by id)
    /// </summary>
    /// <param name="allFormComponents">sorted dictionary containing all web form fields (ID,Value)</param>
    /// <returns>stirng containing all values from all web form fields</returns>
    protected string StringToHashExtended(SortedDictionary<string, string> allFormComponents)
    {
        var result = string.Empty;

        foreach (var item in allFormComponents.Keys)
        {
            if (!(item.Equals("sharedsecret") || item.Equals("chargetotal")))
                result += allFormComponents[item];
        }

        return allFormComponents["chargetotal"] + result + allFormComponents["sharedsecret"];
    }

    /// <summary>
    /// creates all input tags of the send form. Values and ID are taken from sorted dictionary containing all web form fields
    /// </summary>
    /// <param name="allFormComponents">sorted dictionary containing all web form fields (ID,Value)</param>
    /// <returns>string containing all input tags vith ID's and Values for the send form</returns>
    protected string AllInputTagstring(SortedDictionary<string, string> allFormComponents)
    {
        var result = new StringBuilder();

        string input = "<input type=\"hidden\" name=\"{0}\" value=\"{1}\"/>";
        foreach (var item in allFormComponents.Keys)
        {
            result.Append(string.Format(input, item, allFormComponents[item]));
        }

        return result.ToString();
    }

}