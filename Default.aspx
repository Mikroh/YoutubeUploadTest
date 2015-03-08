<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 133px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Log ind</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Brugernavn</td>
                <td>
                    <asp:TextBox ID="TextBoxUsernameLogin" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password</td>
                <td>
                    <asp:TextBox ID="TextBoxPasswordLogin" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="ButtonLogin" runat="server" OnClick="Button1_Click" Text="Log ind" />
                </td>
                <td>
                    <asp:Label ID="LabelFail" runat="server" ForeColor="Red" Text="Det lykkedes ikke at logge ind. Prøv igen"></asp:Label>
                </td>
            </tr>
        </table>

        <asp:Repeater ID="RepeaterVideos" runat="server">
            <ItemTemplate>
                <a href="video.aspx?id=<%# Eval("id") %>"><img src="http://img.youtube.com/vi/<%# Eval("URL") %>/0.jpg" width="100" /></a><a href="video.aspx?id=<%# Eval("Id") %>"><h2><%# Eval("Title") %></h2></a>
                <span>Uploadet af: <%# Eval("Username") %></span>
            </ItemTemplate>
        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
