<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128530150/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T338444)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Card View for ASP.NET Web Forms - How to customize command buttons in individual cards

This example demonstrates how to use the [ASPxCardView.CommandButtonInitialize](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxCardView.CommandButtonInitialize) event to customize command buttons (for instance, disable buttons in odd cards).

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
<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-card-view-customize-command-buttons&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-card-view-customize-command-buttons&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
