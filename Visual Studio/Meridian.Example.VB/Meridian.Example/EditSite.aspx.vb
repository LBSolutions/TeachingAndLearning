Public Class EditSite
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim cSites As Sites
            cSites = Session("Sites")

            Me.txtSiteName.Text = cSites.SelectedItem.SiteName

        End If

    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        Dim cDocTypes As Sites
        cDocTypes = Session("Sites")

        cDocTypes.SelectedItem.SiteName = Me.txtSiteName.Text

        Dim db As DatabaseInterogator = New DatabaseInterogator

        db.SaveObject(cDocTypes.SelectedItem)
        Response.Redirect("DropsDowns.aspx")

    End Sub

End Class