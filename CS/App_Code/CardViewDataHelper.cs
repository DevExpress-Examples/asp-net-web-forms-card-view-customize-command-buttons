using DevExpress.Web;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;

public static class CardViewDataHelper {
	public static DataTable Data {
		get {
			if(HttpContext.Current.Session["data"] == null) {
				var table = new DataTable();
				table.Columns.Add("ID", typeof(int));
				table.Columns.Add("Data", typeof(string));
				table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };
				for(int i = 0; i < 10; i++) {
					table.Rows.Add(new object[] { i, "row " + i.ToString() });
				}
				HttpContext.Current.Session["data"] = table;
			}
			return (DataTable)HttpContext.Current.Session["data"];
		}
	}
	public static void InsertCard(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
		InsertRow(e.NewValues);
		BindCardView(sender as ASPxCardView);
		e.Cancel = true;
	}
	public static void UpdateCard(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
		UpdateRow(e.NewValues, (int)e.Keys[0]);
		BindCardView(sender as ASPxCardView);
		e.Cancel = true;
	}
	public static void DeleteCard(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e) {
		DeleteRow((int)e.Keys[0]);
		BindCardView(sender as ASPxCardView);
		e.Cancel = true;
	}
	static void BindCardView(ASPxCardView cv) {
		cv.CancelEdit();
		cv.DataSource = Data;
		cv.DataBind();
	}
	static int GetNewId(DataTable table) {
		if(table.Rows.Count == 0) return 0;
		int max = Convert.ToInt32(table.Rows[0]["ID"]);
		for(int i = 1; i < table.Rows.Count; i++) {
			if(Convert.ToInt32(table.Rows[i]["ID"]) > max)
				max = Convert.ToInt32(table.Rows[i]["ID"]);
		}
		return max + 1;
	}
	static void UpdateRow(OrderedDictionary newValues, int ID) {
		var row = Data.Rows.Find(ID);
		row["Data"] = newValues["Data"];
		
	}
	static void InsertRow(OrderedDictionary newValues) {
		DataRow row = Data.NewRow();
		row["ID"] = GetNewId(Data);
		row["Data"] = newValues["Data"];
		Data.Rows.Add(row);
	}
	static void DeleteRow(int ID) {
		var row = Data.Rows.Find(ID);
		Data.Rows.Remove(row);
	}
}
