<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128530150/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T338444)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Card View for ASP.NET Web Forms - How to customize command buttons in individual cards
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t338444/)**
<!-- run online end -->

This example demonstrates how to use [ASPxCardView.CommandButtonInitialize](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxCardView.CommandButtonInitialize) event to customize command buttons, for instance, disable buttons in odd cards.

```csharp
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
```

## Files to Review

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
* [CardViewDataHelper.cs](./CS/App_Code/CardViewDataHelper.cs) (VB: [CardViewDataHelper.vb](./VB/App_Code/CardViewDataHelper.vb))
