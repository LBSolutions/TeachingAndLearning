<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DropsDowns.aspx.vb" Inherits="Meridian.Example.DropsDowns" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="MakeItlookGood.css"/>
    <title>Meridian - Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <br />
                <br />
                <asp:DropDownList ID="SiteDropDown" runat="server" CssClass="Dropdown_standard"></asp:DropDownList>
                <asp:Button ID="EditSiteButton" runat="server" Text="Edit" CssClass="Button_standard"/>
                <br />
                <br />
            </div>
            <div>
                <asp:DropDownList ID="DocumentTypeDropDown" runat="server" CssClass="Dropdown_standard">
                </asp:DropDownList>
                <asp:Button ID="EditDocTypeButton" runat="server" Text="Edit" CssClass="Button_standard"/>
            </div>
        </div>
    </form>
</body>
</html>
