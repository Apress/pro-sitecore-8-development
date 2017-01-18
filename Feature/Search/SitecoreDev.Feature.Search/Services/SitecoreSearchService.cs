using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sitecore.ContentSearch.Linq.Utilities;
using SitecoreDev.Feature.Search.Models;
using SitecoreDev.Foundation.Repository.Search;
using Sitecore.ContentSearch.Linq;
using SitecoreDev.Foundation.Model.Search;

namespace SitecoreDev.Feature.Search.Services
{
  public class SitecoreSearchService : ISearchService
  {
    private readonly ISearchRepository _searchRepository;

    public SitecoreSearchService(ISearchRepository searchRepository)
    {
      _searchRepository = searchRepository;
    }

    public IEnumerable<BlogSearchResult> SearchBlogPosts(string searchTerm)
    {
      return _searchRepository.Search<BlogSearchResult>(q => q.Title.Contains(searchTerm) && q.Path.StartsWith("/sitecore/content/Home"));
    }

    public IFacetedSearchResults<BlogSearchResult> SearchBlogPostsWithFacets(string searchTerm, string[] facets)
    {
      var predicate = PredicateBuilder.True<BlogSearchResult>();
      predicate = predicate.And(i => i.Title.Contains(searchTerm) && i.Path.StartsWith("/sitecore/content/Home"));

      if (facets != null)
      {
        foreach (var facet in facets)
        {
          predicate = predicate.And(i => i.Categories.Contains(facet));
        }
      }

      return _searchRepository.SearchWithFacets<BlogSearchResult, IEnumerable<string>>(predicate, q => q.Categories);

      //return _searchRepository.SearchWithFacets<BlogSearchResult, IEnumerable<string>>(
      //  q => q.Title.Contains(searchTerm) && q.Path.StartsWith("/sitecore/content/Home"),
      //  q => q.Categories);
    }

    public IEnumerable<string> GetSearchSuggestions(string searchTerm)
    {
      var suggestions = new List<string>();
      var results = _searchRepository.GetTermsByFieldName("title", searchTerm);
      foreach (var result in results)
      {
        suggestions.Add(result.Term);
      }
      return suggestions;
    }
  }
}