using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Model.Framework;

namespace SitecoreDev.Feature.Marketing.Contacts.Facets
{
  public interface ISubscriptionsFacet : IFacet
  {
    IElementCollection<ITopicSubscriptionElement> Subscriptions { get; }
  }
}