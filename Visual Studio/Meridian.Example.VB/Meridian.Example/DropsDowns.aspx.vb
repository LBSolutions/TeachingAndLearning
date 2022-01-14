Public Class DropsDowns
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'first time or a postback?
        If Not IsPostBack Then

            'instance and load the site data...
            Dim csites As Sites = New Sites
            Dim cdocs As docTypes = New docTypes

            csites.Load()
            cdocs.Load()

            'bind the classes to the relevant drop down...
            With Me.SiteDropDown
                .DataValueField = "SiteId"
                .DataTextField = "SiteName"
                .DataSource = csites
                .DataBind()
            End With

            With DocumentTypeDropDown
                .DataValueField = "DocTypeId"
                .DataTextField = "docTypeName"
                .DataSource = cdocs
                .DataBind()
            End With

            'add newly created list classes to the session for use by other pages
            Session("sites") = csites
            Session("doctypes") = cdocs

        End If

    End Sub

    Protected Sub EditDocTypeButton_Click(sender As Object, e As EventArgs) Handles EditDocTypeButton.Click

        Dim SelectedId As Long
        SelectedId = Me.DocumentTypeDropDown.SelectedValue

        Dim cDoctypes As docTypes = Session("docTypes")
        cDoctypes.SelectedItemId = SelectedId

        Response.Redirect("editDocType.aspx")


    End Sub

    Protected Sub EditSiteButton_Click(sender As Object, e As EventArgs) Handles EditSiteButton.Click

        Dim SelectedId As Long
        SelectedId = Me.SiteDropDown.SelectedValue

        Dim cSites As Sites = Session("Sites")
        cSites.SelectedItemId = SelectedId

        Response.Redirect("editSite.aspx")

    End Sub
End Class