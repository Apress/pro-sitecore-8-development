using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreDev.Feature.Search.ViewModels
{
  public class SearchResultsViewModel
  {
    public List<SearchResultViewModel> Results { get; set; } = new List<SearchResultViewModel>();
    public List<FacetViewModel> Facets { get; set; } = new List<FacetViewModel>();
  }
}