Imports System.Data.SqlClient

Public Class DB

#Region " Build-up Tear-down (Non prod code) "

    Public Shared Sub SetUp()
        DropTables()
        CreateDocTypesTable()
        CreateSitesTable()
        CreateSiteTypeTable()
        InsertDocTypes()
        InsertSites()
        InsertSiteTypes()
    End Sub

    Private Shared Sub DropTables()
        DropSitesTable()
        DropDocTypesTable()
        DropSiteTypeTable()
    End Sub

    Private Shared Sub DropSitesTable()
        Try
            Dim c1 As SqlCommand
            Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)

            c1 = New SqlCommand("DROP TABLE Sites", c2)
            c2.Open()
            c1.ExecuteNonQuery()
            c2.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Shared Sub DropSiteTypeTable()
        Try
            Dim c1 As SqlCommand
            Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)

            c1 = New SqlCommand("DROP TABLE Site_Type", c2)
            c2.Open()
            c1.ExecuteNonQuery()
            c2.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Shared Sub DropDocTypesTable()
        Try
            Dim c1 As SqlCommand
            Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)

            c1 = New SqlCommand("DROP TABLE Doc_Types", c2)
            c2.Open()
            c1.ExecuteNonQuery()
            c2.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Shared Sub CreateSitesTable()
        Dim c1 As SqlCommand
        Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)

        c1 = New SqlCommand("CREATE TABLE Sites (SiteId [int] IDENTITY(1,1) NOT NULL, SiteName VARCHAR(300) NOT NULL)", c2)
        c2.Open()
        c1.ExecuteNonQuery()
        c2.Close()
    End Sub

    Private Shared Sub CreateDocTypesTable()
        Dim c1 As SqlCommand
        Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)

        c1 = New SqlCommand("CREATE TABLE Doc_Types (DocTypeId [int] IDENTITY(1,1) NOT NULL, DocType VARCHAR(150) NOT NULL)", c2)
        c2.Open()
        c1.ExecuteNonQuery()
        c2.Close()
    End Sub

    Private Shared Sub CreateSiteTypeTable()
        Dim c1 As SqlCommand
        Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)

        c1 = New SqlCommand("CREATE TABLE Site_Type (SiteTypeId [int] IDENTITY(1,1) NOT NULL, SiteTypeName VARCHAR(100) NOT NULL)", c2)
        c2.Open()
        c1.ExecuteNonQuery()
        c2.Close()
    End Sub

    Private Shared Sub InsertSites()
        Dim c1 As SqlCommand
        Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)
        Dim s1 As String = ""

        s1 = "INSERT INTO Sites SELECT 'Place 1'"
        s1 &= ";INSERT INTO Sites SELECT 'Place 2'"
        s1 &= ";INSERT INTO Sites SELECT 'Building 909'"
        s1 &= ";INSERT INTO Sites SELECT 'The House'"
        s1 &= ";INSERT INTO Sites SELECT 'Chip Shop'"
        s1 &= ";INSERT INTO Sites SELECT 'Bank'"

        c1 = New SqlCommand(s1, c2)
        c2.Open()
        c1.ExecuteNonQuery()
        c2.Close()
    End Sub

    Private Shared Sub InsertDocTypes()
        Dim c1 As SqlCommand
        Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)
        Dim s1 As String = ""

        s1 = "INSERT INTO Doc_Types SELECT 'Health and Safety'"
        s1 &= ";INSERT INTO Doc_Types SELECT 'DDA'"
        s1 &= ";INSERT INTO Doc_Types SELECT 'Document 2F'"
        s1 &= ";INSERT INTO Doc_Types SELECT 'Asbestos Survey'"

        c1 = New SqlCommand(s1, c2)
        c2.Open()
        c1.ExecuteNonQuery()
        c2.Close()
    End Sub

    Private Shared Sub InsertSiteTypes()
        Dim c1 As SqlCommand
        Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)
        Dim s1 As String = ""

        s1 = "INSERT INTO Site_Type SELECT 'Office'"
        s1 &= ";INSERT INTO Site_Type SELECT 'Residential'"
        s1 &= ";INSERT INTO Site_Type SELECT 'Flats'"

        c1 = New SqlCommand(s1, c2)
        c2.Open()
        c1.ExecuteNonQuery()
        c2.Close()
    End Sub

#End Region

    Public Shared Function ExecuteProc(p1 As String) As DataTable
        Dim c1 As SqlCommand
        Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)
        Dim a1 As SqlDataAdapter
        Dim d1 As DataSet = New DataSet()

        c1 = New SqlCommand()
        c1.CommandType = CommandType.StoredProcedure
        c1.CommandText = p1
        a1 = New SqlDataAdapter(c1)
        c2.Open()
        a1.Fill(d1)
        c2.Close()

        Return d1.Tables(0)
    End Function

    Public Shared Function ExecuteQuery(s1 As String) As DataTable
        Dim c1 As SqlCommand
        Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)
        Dim a1 As SqlDataAdapter
        Dim d1 As DataSet = New DataSet()

        c1 = New SqlCommand(s1, c2)
        a1 = New SqlDataAdapter(c1)
        c2.Open()
        a1.Fill(d1)
        c2.Close()

        Return d1.Tables(0)
    End Function

    Public Shared Sub ExecuteSQL(s1 As String)
        Dim c1 As SqlCommand
        Dim c2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ConnectionString)

        c1 = New SqlCommand(s1, c2)
        c2.Open()
        c1.ExecuteNonQuery()
        c2.Close()
    End Sub

End Class
