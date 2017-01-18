using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using SitecoreDev.Foundation.Indexing.Models;

namespace SitecoreDev.Feature.Search.Models
{
  public class BlogSearchResult : SearchResultItem
  {
    [IndexField("blogtitle")]
    public string Title { get; set; }

    [IndexField("blogbody")]
    public string Body { get; set; }

    [IndexField("haspresentation")]
    public bool HasPresentation { get; set; }

    [IndexField("blogcategories")]
    public IEnumerable<string> Categories { get; set; }
  }
}