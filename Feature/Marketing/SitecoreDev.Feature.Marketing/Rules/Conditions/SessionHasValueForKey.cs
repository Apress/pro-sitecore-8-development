using System;
using System.Web;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace SitecoreDev.Feature.Marketing.Rules.Conditions
{
  public class SessionHasValueForKey<T> : WhenCondition<T> where T : RuleContext
  {
    public string SessionKeyName { get; set; }

    protected override bool Execute(T ruleContext)
    {
      try
      {
        return HttpContext.Current.Session[SessionKeyName] != null && !String.IsNullOrEmpty(HttpContext.Current.Session[SessionKeyName].ToString());
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}