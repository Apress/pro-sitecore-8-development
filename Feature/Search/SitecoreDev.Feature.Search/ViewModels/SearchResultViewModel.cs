using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreDev.Feature.Search.ViewModels
{
  public class SearchResultViewModel
  {
    public string Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Url { get; set; }
    public string CategoryList { get; set; }
  }
}