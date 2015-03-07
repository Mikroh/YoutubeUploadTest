<%@ Page Language="C#" AutoEventWireup="true" CodeFile="video.aspx.cs" Inherits="video" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="VideoRepeater" runat="server">
            <ItemTemplate>
                <h1><%# Eval("title") %></h1>
                <p>Uploadet af: <%# Eval("username") %></p>
                <iframe id="ytplayer" type="text/html" width="720" height="405" src="https://www.youtube.com/embed/<%# Eval("URL") %>" frameborder="0" allowfullscreen>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
