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
            <asp:Label ID="Label1" runat="server" Text="Lance Beacroft Test Results" CssClass="TitleLabel"/>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Sites" id="lblSites" CssClass="label"/>
                    </td>
                    <td>
                        <asp:DropDownList ID="SiteDropDown" runat="server" CssClass="Dropdown_standard"/>
                    </td>
                    <td>
                        <asp:Button ID="EditSiteButton" runat="server" Text="Edit" CssClass="Button_standard"/>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Documents" id="lblDocuments" CssClass="label"/></td>
                    <td><asp:DropDownList ID="DocumentTypeDropDown" runat="server" CssClass="Dropdown_standard"/></td>
                    <td> <asp:Button ID="EditDocTypeButton" runat="server" Text="Edit" CssClass="Button_standard"/></td>
                </tr>
            </table>

                
            </div>
            <div>
                
        </div>
    </form>
</body>
</html>
