<%@ Page Language="VB" %>

<!DOCTYPE html>
<script runat="server">

    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub
</script>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">
<meta charset="utf-8" />
    <link rel="stylesheet" href="MakeItlookGood.css"/>
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">   
        <br />
        
        <asp:Table ID="Table1" runat="server" Width="50%" CssClass="Table">
            
            <asp:TableHeaderRow CssClass="row_Header">
                <asp:TableCell>Control</asp:TableCell><asp:TableCell>Class</asp:TableCell>
            </asp:TableHeaderRow>
            
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="Button1" runat="server" Text="Button" CssClass="Button_standard"/></asp:TableCell><asp:TableCell>Button_standard</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell><asp:Button ID="Button2" runat="server" Text="Button" CssClass="Button_standard button_wide"/></asp:TableCell><asp:TableCell>Button_standard + button_wide</asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell><asp:DropDownList ID="DropDownList1" runat="server" CssClass="Dropdown_standard">
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
            </asp:DropDownList></asp:TableCell>
                <asp:TableCell>Dropdown_standard</asp:TableCell>
            </asp:TableRow>

        </asp:Table>
        
        <br />
        <br />
    </form>
</body>
</html>
