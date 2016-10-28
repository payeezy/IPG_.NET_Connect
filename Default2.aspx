<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Extended Hash</title>
</head>
<body>
    <asp:HyperLink ID="hashClassic" runat="server" Text="Hash" NavigateUrl="~/Default.aspx" />
    <asp:HyperLink ID="extendedHash" runat="server" Text="Extended Hash" NavigateUrl="~/Default2.aspx" />
    <form id="form" runat="server">
    <table border="0">
        <tr>
            <td style="width: 169px; height: 12px;">
                Hash Algorithm
            </td>
            <td style="height: 12px;">
                <asp:DropDownList ID="hash_algorithm" name="hash_algorithm" runat="server" Width="154px">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="SHA1">SHA1</asp:ListItem>
                    <asp:ListItem Value="SHA256">SHA256</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 12px; width: 118px;">
                Store Id:
            </td>
            <td style="width: 169px; height: 12px;">
                <asp:TextBox ID="storename" name="storename" runat="server" Width="150px">120995000</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                Shared Secret:
            </td>
            <td style="width: 169px; height: 12px;">
                <asp:TextBox ID="sharedsecret" name="sharedsecret" runat="server" Width="150px">sharedsecret</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 169px; height: 12px;">
                PMTH
            </td>
            <td style="height: 12px;">
                <asp:DropDownList ID="paymentMethod" name="paymentMethod" runat="server" Width="154px">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="M">MasterCard</asp:ListItem>
                    <asp:ListItem Value="V">Visa</asp:ListItem>
                    <asp:ListItem Value="A">AmEx</asp:ListItem>
                    <asp:ListItem Value="maestroUK">MaestroUK</asp:ListItem>
                    <asp:ListItem Value="MA">Maestro</asp:ListItem>
                    <asp:ListItem Value="C">Diners</asp:ListItem>
                    <asp:ListItem Value="J">JCB</asp:ListItem>
                    <asp:ListItem Value="L">Laser</asp:ListItem>
                    <asp:ListItem Value="IKEA">IKEA</asp:ListItem>
                    <asp:ListItem Value="debitDE">DirectDebit</asp:ListItem>
                    <asp:ListItem Value="giropay">Giropay</asp:ListItem>
                    <asp:ListItem Value="paypal">Paypal</asp:ListItem>
                    <asp:ListItem Value="clickAndBuy">ClickandBuy</asp:ListItem>
                    <asp:ListItem Value="CUP">ChinaUnionPay</asp:ListItem>
                    <asp:ListItem Value="direkt">Direkt</asp:ListItem>
                    <asp:ListItem Value="AirTel">AirTel</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                Payment Mode:
            </td>
            <td style="width: 169px; height: 12px;">
                <asp:DropDownList ID="mode" name="mode" runat="server" Width="91px">
                    <asp:ListItem Value="payonly">PayOnly</asp:ListItem>
                    <asp:ListItem Value="payplus">PayPlus</asp:ListItem>
                    <asp:ListItem Value="fullpay">FullPay</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                TimeZone
            </td>
            <td style="width: 169px; height: 12px;">
                <asp:TextBox ID="timezone" name="timezone" runat="server" Width="48px">UTC+01:00</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                TxnType
            </td>
            <td style="height: 12px;">
                <asp:DropDownList ID="txntype" name="txntype" runat="server" Width="87px">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="sale" Selected="True">Sale</asp:ListItem>
                    <asp:ListItem Value="void">void</asp:ListItem>
                    <asp:ListItem Value="preauth">preauth</asp:ListItem>
                    <asp:ListItem Value="postauth">postauth</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                Chargetotal:
            </td>
            <td style="width: 169px; height: 12px;">
                <asp:TextBox ID="chargetotal" runat="server" Width="90px">13.99</asp:TextBox>
                <asp:DropDownList ID="currency" name="currency" runat="server" Width="64px">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="978" Selected="True">EUR</asp:ListItem>
                    <asp:ListItem Value="826">GBP</asp:ListItem>
                    <asp:ListItem Value="840">USD</asp:ListItem>
                    <asp:ListItem Value="756">CHF</asp:ListItem>
                    <asp:ListItem Value="392">JPY</asp:ListItem>
                    <asp:ListItem Value="710">ZAR</asp:ListItem>
                    <asp:ListItem Value="752">SEK</asp:ListItem>
                    <asp:ListItem Value="124">CAD</asp:ListItem>
                    <asp:ListItem Value="985">PLN</asp:ListItem>
                    <asp:ListItem Value="208">DKK</asp:ListItem>
                    <asp:ListItem Value="203">CZK</asp:ListItem>
                    <asp:ListItem Value="048">BHD</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                TxnDateTime
            </td>
            <td style="width: 118px; height: 12px;">
                <asp:TextBox ID="txndatetime" name="txndatetime" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                Hash
            </td>
            <td style="width: 300px; height: 12px;">
                <asp:TextBox ID="hashExtended" name="hash" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                Order Id
            </td>
            <td style="width: 118px; height: 12px;">
                <asp:TextBox ID="oid" name="oid" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                Language:
            </td>
            <td style="width: 118px; height: 12px;">
                <asp:DropDownList ID="language" name="language" runat="server">
                    <asp:ListItem Value=""> </asp:ListItem>
                    <asp:ListItem Value="de_DE">Deutsch</asp:ListItem>
                    <asp:ListItem Value="en_US" Selected="True">English</asp:ListItem>
                    <asp:ListItem Value="en_EN">English en_EN</asp:ListItem>
                    <asp:ListItem Value="it_IT">Italy</asp:ListItem>
                    <asp:ListItem Value="fi_FI">Finland</asp:ListItem>
                    <asp:ListItem Value="fr_FR">French</asp:ListItem>
                    <asp:ListItem Value="pt_BR">Brazil</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                Response Success URL
            </td>
            <td style="width: 374px; height: 12px;">
                <asp:TextBox ID="responseSuccessURL" name="responseSuccessURL" runat="server" Width="374px">https://test.ipg-online.com/webshop/response_success.jsp</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 118px; height: 12px;">
                Response Failure URL
            </td>
            <td style="width: 374px; height: 12px;">
                <asp:TextBox ID="responseFailURL" name="responseFailURL" runat="server" Width="374px">https://test.ipg-online.com/webshop/response_failure.jsp</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                &nbsp;
                <asp:Button ID="btnSend" runat="server" Text="Submit" OnClick="btnSend_Click" />
            </td>
        </tr>
    </table>
    </form>
    <asp:Literal ID="ltrForm" runat="server" Mode="PassThrough"></asp:Literal>
    <asp:Literal ID="ltrScript" runat="server" Mode="PassThrough"></asp:Literal>
    <div>
    </div>
</body>
</html>