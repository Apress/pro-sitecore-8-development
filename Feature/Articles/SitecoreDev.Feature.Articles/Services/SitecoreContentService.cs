using SitecoreDev.Feature.Articles.Models;
using SitecoreDev.Foundation.Repository.Content;

namespace SitecoreDev.Feature.Articles.Services
{
   public class SitecoreContentService : IContentService
   {
      private readonly IContentRepository _repository;

      public SitecoreContentService(IContentRepository repository)
      {
         _repository = repository;
      }

      public IArticle GetArticleContent(string contentGuid)
      {
         return _repository.GetContentItem<IArticle>(contentGuid);
      }
   }
}