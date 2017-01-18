using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Model.Framework;

namespace SitecoreDev.Feature.Marketing.Contacts.Facets
{
  [Serializable]
  public class SubscriptionsFacet : Facet, ISubscriptionsFacet
  {
    public static readonly string EntryCollectionName = "Subscriptions";

    public IElementCollection<ITopicSubscriptionElement> Subscriptions { get { return GetCollection<ITopicSubscriptionElement>(EntryCollectionName); } }

    public SubscriptionsFacet()
    {
      EnsureCollection<ITopicSubscriptionElement>(EntryCollectionName);
    }
  }
}