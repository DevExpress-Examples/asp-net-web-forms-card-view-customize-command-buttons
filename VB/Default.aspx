<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxCardView ID="ASPxCardView1" KeyFieldName="ID" AutoGenerateColumns="False" runat="server" 
				OnCommandButtonInitialize="ASPxCardView1_CommandButtonInitialize" ClientInstanceName="card" 
				OnCardInserting="ASPxCardView1_CardInserting" OnCardUpdating="ASPxCardView1_CardUpdating" OnCardDeleting="ASPxCardView1_CardDeleting">
				<Columns>
					<dx:CardViewTextColumn FieldName="ID" VisibleIndex="0" ReadOnly="true">						
					</dx:CardViewTextColumn>
					<dx:CardViewTextColumn FieldName="Data" VisibleIndex="1">
					</dx:CardViewTextColumn>
				</Columns>
				<CardLayoutProperties>
					<Items>
						<dx:CardViewCommandLayoutItem HorizontalAlign="Right" ShowEditButton="True" ShowDeleteButton="true" ShowNewButton="true">
						</dx:CardViewCommandLayoutItem>						
						<dx:CardViewColumnLayoutItem ColumnName="Data">
						</dx:CardViewColumnLayoutItem>
						<dx:EditModeCommandLayoutItem HorizontalAlign="Right">
						</dx:EditModeCommandLayoutItem>
					</Items>
				</CardLayoutProperties>
			</dx:ASPxCardView>
		</div>
	</form>
</body>
</html>