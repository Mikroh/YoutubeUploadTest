<%@ Page Language="C#" AutoEventWireup="true" CodeFile="my_account.aspx.cs" Inherits="my_account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 105px;
        }
        .auto-style3 {
            width: 105px;
            height: 30px;
        }
        .auto-style4 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>IT WERKS!!!!!</h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Video URL</td>
                <td>
                    <asp:TextBox ID="TextBoxURL" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Title</td>
                <td>
                    <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4">
                    <asp:Button ID="ButtonUpload" runat="server" OnClick="ButtonUpload_Click" Text="Upload dat shit" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="LabelSuccess" runat="server" ForeColor="#00CC00" Text="Le upload is complete"></asp:Label>
                </td>
            </tr>
        </table>
        <a href="my_account.aspx?logout=true">Log ud</a>
    </div>
    </form>
</body>
</html>
