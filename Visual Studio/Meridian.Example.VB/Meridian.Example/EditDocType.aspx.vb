Public Class EditDocType
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim cDocTypes As docTypes
            cDocTypes = Session("DocTypes")

            Me.txtDocType.Text = cDocTypes.SelectedItem.docTypeName

        End If

    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        Dim cDocTypes As docTypes
        cDocTypes = Session("DocTypes")

        cDocTypes.SelectedItem.docTypeName = Me.txtDocType.Text

        Dim db As DatabaseInterogator = New DatabaseInterogator

        db.SaveObject(cDocTypes.SelectedItem)
        Response.Redirect("DropsDowns.aspx")


    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click

        Response.Redirect("DropsDowns.aspx")

    End Sub
End Class