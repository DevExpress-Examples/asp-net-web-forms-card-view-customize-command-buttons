Imports System
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		ASPxCardView1.DataSource = CardViewDataHelper.Data
		ASPxCardView1.DataBind()
	End Sub
	Protected Sub ASPxCardView1_CommandButtonInitialize(ByVal sender As Object, ByVal e As ASPxCardViewCommandButtonEventArgs)
		Dim isOddRow As Boolean = e.VisibleIndex Mod 2 = 0
		If isOddRow Then
			If e.ButtonType = CardViewCommandButtonType.Edit Then
				e.Enabled = False
			End If
			If e.ButtonType = CardViewCommandButtonType.[New] Then
				e.Enabled = False
			End If
			If e.ButtonType = CardViewCommandButtonType.Delete Then
				e.Enabled = False
			End If
		End If
	End Sub
	Protected Sub ASPxCardView1_CardInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
		CardViewDataHelper.InsertCard(sender, e)
	End Sub
	Protected Sub ASPxCardView1_CardUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
		CardViewDataHelper.UpdateCard(sender, e)
	End Sub
	Protected Sub ASPxCardView1_CardDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
		CardViewDataHelper.DeleteCard(sender, e)
	End Sub
End Class