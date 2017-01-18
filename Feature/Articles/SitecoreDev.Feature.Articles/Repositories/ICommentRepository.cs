using System.Collections.Generic;
using SitecoreDev.Feature.Articles.Models;

namespace SitecoreDev.Feature.Articles.Repositories
{
   public interface ICommentRepository
   {
      IEnumerable<IComment> GetComments(string blogId);
   }
}