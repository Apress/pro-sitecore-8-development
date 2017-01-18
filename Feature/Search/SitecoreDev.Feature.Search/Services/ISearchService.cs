using System.Collections.Generic;
using Sitecore.ContentSearch.SearchTypes;
using SitecoreDev.Feature.Search.Models;
using SitecoreDev.Foundation.Model.Search;

namespace SitecoreDev.Feature.Search.Services
{
  public interface ISearchService
  {
    IEnumerable<BlogSearchResult> SearchBlogPosts(string searchTerm);
    IFacetedSearchResults<BlogSearchResult> SearchBlogPostsWithFacets(string searchTerm, string[] facets);
    IEnumerable<string> GetSearchSuggestions(string searchTerm);
  }
}