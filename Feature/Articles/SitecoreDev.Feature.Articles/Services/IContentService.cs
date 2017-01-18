using SitecoreDev.Feature.Articles.Models;

namespace SitecoreDev.Feature.Articles.Services
{
   public interface IContentService
   {
      IArticle GetArticleContent(string contentGuid);
   }
}