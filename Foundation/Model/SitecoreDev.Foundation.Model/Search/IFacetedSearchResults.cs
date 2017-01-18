using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.ContentSearch.SearchTypes;

namespace SitecoreDev.Foundation.Model.Search
{
  public interface IFacetedSearchResults<T> where T : SearchResultItem
  {
    IEnumerable<T> Results { get; set; }
    IEnumerable<Facet> Facets { get; set; }
  }
}
