using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using SitecoreDev.Foundation.Model.Search;

namespace SitecoreDev.Foundation.Repository.Search
{
  public class SitecoreSearchRepository : ISearchRepository
  {
    public IEnumerable<T> Search<T>(Expression<Func<T, bool>> query) where T : SearchResultItem
    {
      IEnumerable<T> results = null;

      var index = String.Format("sitecore_{0}_index", Sitecore.Context.Database.Name);

      using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
      {
        results = context.GetQueryable<T>().Where(query).ToList();
      }

      return results;
    }

    public IFacetedSearchResults<T> SearchWithFacets<T, TFacetKey>(Expression<Func<T, bool>> query, Expression<Func<T, TFacetKey>> facetOn) 
      where T : SearchResultItem
    {
      var results = new FacetedSearchResults<T>();
      List<T> searchResults = new List<T>();
      List<Facet> facets = new List<Facet>();

      var index = String.Format("sitecore_{0}_index", Sitecore.Context.Database.Name);

      using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
      {
        var searchHits = context.GetQueryable<T>().Where(query).FacetOn(facetOn).GetResults();

        foreach(var hit in searchHits)
        {
          searchResults.Add((T)hit.Document);
        }
        foreach(var category in searchHits.Facets.Categories)
        {
          foreach(var facet in category.Values)
          {
            facets.Add(new Facet()
            {
              Name = facet.Name,
              Count = facet.AggregateCount
            });
          }
        }

        results.Results = searchResults;
        results.Facets = facets;
      }

      return results;
    }

    public IEnumerable<SearchIndexTerm> GetTermsByFieldName(string fieldName, string searchTerm)
    {
      IEnumerable<SearchIndexTerm> results = null;

      var index = String.Format("sitecore_{0}_index", Sitecore.Context.Database.Name);

      using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
      {
        results = context.GetTermsByFieldName(fieldName, searchTerm).ToList();
      }

      return results;
    }
  }
}