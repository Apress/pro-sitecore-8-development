using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using SitecoreDev.Foundation.Model.Search;

namespace SitecoreDev.Foundation.Repository.Search
{
  public interface ISearchRepository
  {
    IEnumerable<T> Search<T>(Expression<Func<T, bool>> query) where T : SearchResultItem;
    IFacetedSearchResults<T> SearchWithFacets<T, TFacetKey>(Expression<Func<T, bool>> query, Expression<Func<T, TFacetKey>> facetOn) where T : SearchResultItem;
    IEnumerable<SearchIndexTerm> GetTermsByFieldName(string fieldName, string searchTerm);
  }
}