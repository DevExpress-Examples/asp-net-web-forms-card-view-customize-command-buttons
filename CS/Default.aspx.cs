using System;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
	protected void Page_Init(object sender, EventArgs e) {
		ASPxCardView1.DataSource = CardViewDataHelper.Data;
		ASPxCardView1.DataBind();
	}
	protected void ASPxCardView1_CommandButtonInitialize(object sender, ASPxCardViewCommandButtonEventArgs e) {
		bool isOddRow = e.VisibleIndex % 2 == 0;
		if(isOddRow) {
			if(e.ButtonType == CardViewCommandButtonType.Edit)
				e.Enabled = false;
			if(e.ButtonType == CardViewCommandButtonType.New)
				e.Enabled = false;
			if(e.ButtonType == CardViewCommandButtonType.Delete)
				e.Enabled = false;
		}
	}
	protected void ASPxCardView1_CardInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
		CardViewDataHelper.InsertCard(sender, e);		
	}
	protected void ASPxCardView1_CardUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
		CardViewDataHelper.UpdateCard(sender, e);		
	}
	protected void ASPxCardView1_CardDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e) {
		CardViewDataHelper.DeleteCard(sender, e);		
	}
}