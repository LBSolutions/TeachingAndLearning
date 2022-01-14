Imports System.Data.SqlClient

Public Interface iSave
    Function savesql() As String

End Interface
Public Class DatabaseInterogator
    Public Function GetRecordset(strSQL As String) As DataSet
        Return ProcessSql(strSQL)
    End Function

    Public Function SaveObject(objectToSave As iSave) As Boolean

        Try
            Dim strsql = objectToSave.savesql
            ExecuteCommand(strsql)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function GetConnection() As SqlConnection
        Try
            Dim myCnn As SqlConnection
            Dim DbString As String = ConfigurationManager.ConnectionStrings("MeridianExampleDBConnectionString").ToString
            myCnn = New SqlConnection(DbString)
            Return myCnn

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Private Function ExecuteCommand(StrSQLCommand As String) As Boolean

        Try
            Dim myCnn As SqlConnection = GetConnection()
            myCnn.Open()
            Dim cmd As SqlCommand = New SqlCommand(StrSQLCommand, myCnn)
            cmd.ExecuteNonQuery()
            myCnn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function ProcessSql(strsql As String) As DataSet

        Dim myCnn As SqlConnection = GetConnection()

        Try
            myCnn.Open()
        Catch ex As Exception

        End Try

        Dim ds As DataSet = New DataSet
        Dim cmd As New SqlClient.SqlCommand
        cmd.Connection = myCnn
        cmd.CommandText = strsql
        cmd.CommandTimeout = 6000
        Dim oDataAdapter As New SqlClient.SqlDataAdapter(cmd)
        oDataAdapter.Fill(ds)
        myCnn.Close()

        Return ds

    End Function

End Class
Public Class docTypes
    Implements IEnumerable

    Private lselectedItem As Long

    Private colSites As Collection = New Collection

    Public Function Load() As Boolean

        Dim di As DatabaseInterogator = New DatabaseInterogator
        Dim strSQl As String = "Select DocTypeId, DocType from Doc_types"

        Dim ds As DataSet
        ds = di.GetRecordset(strSQl)

        For Each row In ds.Tables.Item(0).Rows
            Dim nst = New docType
            With nst
                .DocTypeID = row(0)
                .docTypeName = row(1)
            End With
            colSites.Add(nst, nst.DocTypeID)
        Next

        Return True

    End Function

    Private selectedObject As docType
    Public ReadOnly Property SelectedItem As docType
        Get
            Return selectedObject
        End Get
    End Property

    Public Property SelectedItemId As Long
        Get
            Return lselectedItem
        End Get
        Set(value As Long)
            lselectedItem = value
            selectedObject = colSites.Item(lselectedItem)
        End Set
    End Property

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return colSites.GetEnumerator
    End Function

End Class
Public Class docType
    Implements iSave

    Dim lDocTypeId As Long
    Dim strDocTypeName As String
    Dim bHasChanged As Boolean = False
    Public Property haschanged As Boolean
        Get
            Return bHasChanged
        End Get
        Set(value As Boolean)
            bHasChanged = value
        End Set
    End Property

    Public Property docTypeName As String
        Get
            Return strDocTypeName
        End Get
        Set(value As String)
            strDocTypeName = value
            bHasChanged = True
        End Set
    End Property

    Public Property DocTypeID As Long
        Get
            Return lDocTypeId
        End Get
        Set(ByVal value As Long)
            lDocTypeId = value
        End Set
    End Property

    Public Function savesql() As String Implements iSave.savesql
        Return "update DOC_TYPES set DocType='" & strDocTypeName & "' where doctypeid = " & lDocTypeId.ToString
    End Function
End Class
Public Class siteTypes
    Implements IEnumerable

    Private colSitetypes As Collection = New Collection

    Public Function Load() As Boolean

        Dim di As DatabaseInterogator = New DatabaseInterogator
        Dim strSQl As String = "Select siteTypeId, SitetypeName from Site_type"

        Dim ds As DataSet
        ds = di.GetRecordset(strSQl)

        For Each row In ds.Tables.Item(0).Rows
            Dim nst = New sitetype
            With nst
                .SiteTypeID = row(0)
                .SiteTypeName = row(1)
            End With
            colSitetypes.Add(nst)
        Next

        Return True

    End Function

    Private selectedObject As sitetype
    Private lselectedItem As Long

    Public ReadOnly Property SelectedItem As sitetype
        Get
            Return selectedObject
        End Get
    End Property

    Public Property SelectedItemId As Long
        Get
            Return lselectedItem
        End Get
        Set(value As Long)
            lselectedItem = value
            selectedObject = colSitetypes.Item(lselectedItem)
        End Set
    End Property

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return colSitetypes.GetEnumerator
    End Function

End Class
Public Class sitetype
    Implements iSave

    Private lSiteTypeID As Long
    Private strSiteTypeName As String
    Dim bHasChanged As Boolean = False
    Public Property haschanged As Boolean
        Get
            Return bHasChanged
        End Get
        Set(value As Boolean)
            bHasChanged = value
        End Set
    End Property

    Public Property SiteTypeID
        Get
            Return lSiteTypeID
        End Get
        Set(value)
            lSiteTypeID = value
        End Set
    End Property

    Public Property SiteTypeName
        Get
            Return strSiteTypeName
        End Get
        Set(value)
            strSiteTypeName = value
            bHasChanged = True
        End Set
    End Property

    Public Function savesql() As String Implements iSave.savesql
        Return "update SITE_TYPE set SiteTypeName='" & strSiteTypeName & "' where doctypeid = " & lSiteTypeID.ToString
    End Function
End Class
Public Class Sites
    Implements IEnumerable

    Private colSites As Collection = New Collection

    Public Function Load() As Boolean

        Dim di As DatabaseInterogator = New DatabaseInterogator
        Dim strSQl As String = "Select siteId, SiteName from Sites"

        Dim ds As DataSet
        ds = di.GetRecordset(strSQl)

        For Each row In ds.Tables.Item(0).Rows
            Dim nst = New Site
            With nst
                .SiteID = row(0)
                .SiteName = row(1)
            End With
            colSites.Add(nst)
        Next

        Return True

    End Function

    Private selectedObject As Site
    Private lselectedItem As Long

    Public ReadOnly Property SelectedItem As Site
        Get
            Return selectedObject
        End Get
    End Property

    Public Property SelectedItemId As Long
        Get
            Return lselectedItem
        End Get
        Set(value As Long)
            lselectedItem = value
            selectedObject = colSites.Item(lselectedItem)
        End Set
    End Property

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return colSites.GetEnumerator
    End Function

End Class
Public Class Site
    Implements iSave

    Dim lSiteId As Long
    Dim strSiteName As String
    Dim bHasChanged As Boolean = False
    Public Property haschanged As Boolean
        Get
            Return bHasChanged
        End Get
        Set(value As Boolean)
            bHasChanged = value
        End Set
    End Property
    Public Property SiteName As String
        Get
            Return strSiteName
        End Get
        Set(value As String)
            strSiteName = value
            bHasChanged = True
        End Set
    End Property

    Public Property SiteID As Long
        Get
            Return lSiteId
        End Get
        Set(ByVal value As Long)
            lSiteId = value
        End Set
    End Property

    Public Function savesql() As String Implements iSave.savesql
        Return "update Sites set SiteName='" & strSiteName & "' where Siteid = " & lSiteId.ToString
    End Function
End Class