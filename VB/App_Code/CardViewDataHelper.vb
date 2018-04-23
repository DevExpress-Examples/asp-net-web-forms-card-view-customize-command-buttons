Option Infer On

Imports DevExpress.Web
Imports System
Imports System.Collections.Specialized
Imports System.Data
Imports System.Web

Public NotInheritable Class CardViewDataHelper

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Data() As DataTable
        Get
            If HttpContext.Current.Session("data") Is Nothing Then

                Dim table = New DataTable()
                table.Columns.Add("ID", GetType(Integer))
                table.Columns.Add("Data", GetType(String))
                table.PrimaryKey = New DataColumn() { table.Columns("ID") }
                For i As Integer = 0 To 9
                    table.Rows.Add(New Object() { i, "row " & i.ToString() })
                Next i
                HttpContext.Current.Session("data") = table
            End If

            Return DirectCast(HttpContext.Current.Session("data"), DataTable)
        End Get
    End Property
    Public Shared Sub InsertCard(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        InsertRow(e.NewValues)
        BindCardView(TryCast(sender, ASPxCardView))
        e.Cancel = True
    End Sub
    Public Shared Sub UpdateCard(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        UpdateRow(e.NewValues, CInt((e.Keys(0))))
        BindCardView(TryCast(sender, ASPxCardView))
        e.Cancel = True
    End Sub
    Public Shared Sub DeleteCard(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        DeleteRow(CInt((e.Keys(0))))
        BindCardView(TryCast(sender, ASPxCardView))
        e.Cancel = True
    End Sub
    Private Shared Sub BindCardView(ByVal cv As ASPxCardView)
        cv.CancelEdit()
        cv.DataSource = Data
        cv.DataBind()
    End Sub
    Private Shared Function GetNewId(ByVal table As DataTable) As Integer
        If table.Rows.Count = 0 Then
            Return 0
        End If
        Dim max As Integer = Convert.ToInt32(table.Rows(0)("ID"))
        For i As Integer = 1 To table.Rows.Count - 1
            If Convert.ToInt32(table.Rows(i)("ID")) > max Then
                max = Convert.ToInt32(table.Rows(i)("ID"))
            End If
        Next i
        Return max + 1
    End Function
    Private Shared Sub UpdateRow(ByVal newValues As OrderedDictionary, ByVal ID As Integer)
        Dim row = Data.Rows.Find(ID)
        row("Data") = newValues("Data")

    End Sub
    Private Shared Sub InsertRow(ByVal newValues As OrderedDictionary)
        Dim row As DataRow = Data.NewRow()
        row("ID") = GetNewId(Data)
        row("Data") = newValues("Data")
        Data.Rows.Add(row)
    End Sub
    Private Shared Sub DeleteRow(ByVal ID As Integer)
        Dim row = Data.Rows.Find(ID)
        Data.Rows.Remove(row)
    End Sub
End Class