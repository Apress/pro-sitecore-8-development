using System.Collections.Generic;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Foundation.Repository.Content
{
   public interface IContentRepository
   {
      T GetContentItem<T>(string contentGuid) where T : class, ICmsEntity;
      IEnumerable<T> GetChildren<T>(string parentGuid) where T : class, ICmsEntity;
   }
}
