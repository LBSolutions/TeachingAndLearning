<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditDocType.aspx.vb" Inherits="Meridian.Example.EditDocType" %>
<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><link rel="stylesheet" href="MakeItlookGood.css"/><title></title></head><body><form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Doc Type Name Edit" CssClass="label"></asp:Label>
            <br />

            <asp:TextBox runat="server" ID="txtDocType" CssClass="TextBox" Width="301px"/>
            <br />
            <br />
            <asp:Button ID="SaveButton" runat="server" Text="Save"  CssClass="Button_standard button_wide"/>
        </div>
    </form>
</body>
</html>
