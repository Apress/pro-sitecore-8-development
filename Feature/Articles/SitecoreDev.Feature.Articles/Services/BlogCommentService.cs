using System.Collections.Generic;
using System.Linq;
using SitecoreDev.Feature.Articles.Models;
using SitecoreDev.Feature.Articles.Repositories;

namespace SitecoreDev.Feature.Articles.Services
{
   public class BlogCommentService : ICommentService
   {
      private readonly ICommentRepository _repository;

      public BlogCommentService(ICommentRepository repository)
      {
         _repository = repository;
      }

      public IEnumerable<IComment> GetComments(string blogId)
      {
         return _repository.GetComments(blogId).OrderBy(c => c.DatePosted);
      }
   }
}