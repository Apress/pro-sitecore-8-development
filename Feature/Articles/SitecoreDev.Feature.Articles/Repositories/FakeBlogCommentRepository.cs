using System;
using System.Collections.Generic;
using SitecoreDev.Feature.Articles.Models;

namespace SitecoreDev.Feature.Articles.Repositories
{
   public class FakeBlogCommentRepository : ICommentRepository
   {
      public IEnumerable<IComment> GetComments(string blogId)
      {
         var comments = new List<IComment>();
         comments.Add(new BlogComment() { Name = "Jack", Comment = "This post was really helpful!", DatePosted = DateTime.Parse("05/12/2016") });
         comments.Add(new BlogComment() { Name = "Jane", Comment = "You're a really smart guy!  Keep up the good work!", DatePosted = DateTime.Parse("03/16/2016") });
         return comments;
      }
   }
}