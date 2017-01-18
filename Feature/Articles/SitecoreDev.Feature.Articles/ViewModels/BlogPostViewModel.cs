using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreDev.Feature.Articles.ViewModels
{
   public class BlogPostViewModel
   {
      public string Title { get; set; }
      public bool HasTitle { get { return !String.IsNullOrEmpty(Title); } }
      public string Body { get; set; }
      public List<BlogCommentViewModel> Comments { get; set; } = new List<BlogCommentViewModel>();
      public bool HasComments { get { return Comments.Count > 0; } }
   }
}