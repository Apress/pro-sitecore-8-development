using System.Collections.Generic;
using SitecoreDev.Feature.Articles.Models;

namespace SitecoreDev.Feature.Articles.Services
{
   public interface ICommentService
   {
      IEnumerable<IComment> GetComments(string blogId);
   }
}