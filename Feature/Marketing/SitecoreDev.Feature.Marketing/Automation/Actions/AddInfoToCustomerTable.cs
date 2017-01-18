using System.Data.SqlClient;
using Sitecore.Analytics.Automation;
using Sitecore.Diagnostics;

namespace SitecoreDev.Feature.Marketing.Automation.Actions
{
  public class AddInfoToCustomerTable : IAutomationAction
  {
    public AutomationActionResult Execute(AutomationActionContext context)
    {
      Assert.ArgumentNotNull(context, "context");

      using (var connection = new SqlConnection("<your connection string>"))
      {
        //Add code to insert information into database table
      }

      return AutomationActionResult.Continue;
    }
  }
}