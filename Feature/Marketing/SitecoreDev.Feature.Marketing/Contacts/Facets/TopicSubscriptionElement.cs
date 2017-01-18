using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Model.Framework;

namespace SitecoreDev.Feature.Marketing.Contacts.Facets
{
  public class TopicSubscriptionElement : Element, ITopicSubscriptionElement
  {
    private const string _topic = "Topic";
    public string Topic { get { return GetAttribute<string>(_topic); } set { SetAttribute(_topic, value); } }

    public TopicSubscriptionElement()
    {
      EnsureAttribute<string>(_topic);
    }
  }
}