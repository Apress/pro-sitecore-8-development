using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using log4net;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.Tracking.External;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.WFFM.Abstractions.Actions;
using Sitecore.WFFM.Actions.Base;

namespace SitecoreDev.Feature.Marketing.Wffm.Actions
{
  public class SaveToCommentDatabase : WffmSaveAction
  {
    private ILog _log;

    public override void Execute(ID formId, AdaptedResultList adaptedFields, ActionCallContext actionCallContext = null, params object[] data)
    {
      _log = Sitecore.Diagnostics.LoggerFactory.GetLogger("LogFileAppender");

      var name = adaptedFields.GetEntryByName("Name");
      var email = adaptedFields.GetEntryByName("Email");
      var comment = adaptedFields.GetEntryByName("Comment");

      _log.Info("Writing comment to database");
      HttpContext.Current.Session["Email"] = email;

      var goal = new PageEventData("My Custom Goal", Guid.Parse("{47FF654B-76B2-49EF-A6AA-C61AE6093768}"));
      Tracker.Current.CurrentPage.Register(goal);

      var contact = Tracker.Current?.Contact;
      if (contact != null)
      {
        var commentCounterTag = contact.Tags.Find("CommentCounter");
        if (commentCounterTag == null)
          contact.Tags.Set("CommentCounter", "1");
        else
        {
          int originalValue = 0;
          int newValue = 0;

          var counter = commentCounterTag.Values.FirstOrDefault();
          if (counter != null)
          {
            if (Int32.TryParse(counter.Value, out originalValue))
            {
              newValue = originalValue + 1;
              contact.Tags.Remove("CommentCounter", originalValue.ToString());
              contact.Tags.Set("CommentCounter", newValue.ToString());
            }
          }

          if (originalValue < 10 && newValue >= 10)
            contact.Extensions.SimpleValues["ContributionLevel"] = "Fanboy";
        }
      }
    }
  }
}