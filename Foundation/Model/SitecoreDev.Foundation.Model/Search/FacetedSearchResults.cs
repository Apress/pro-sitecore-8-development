using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.ContentSearch.SearchTypes;

namespace SitecoreDev.Foundation.Model.Search
{
  public class FacetedSearchResults<T> : IFacetedSearchResults<T> where T : SearchResultItem
  {
    public IEnumerable<T> Results { get; set; }
    public IEnumerable<Facet> Facets { get; set; }
  }
}
