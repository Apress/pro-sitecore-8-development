using System;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using SitecoreDev.Feature.Articles.Services;
using SitecoreDev.Feature.Articles.ViewModels;

namespace SitecoreDev.Feature.Articles.Controllers
{
   public class ArticlesController : Controller
   {
      private readonly IContentService _contentService;
      private readonly ICommentService _commentService;

      public ArticlesController(IContentService contentService, ICommentService commentService)
      {
         _contentService = contentService;
         _commentService = commentService;
      }

      public ViewResult BlogPost()
      {
         var viewModel = new BlogPostViewModel();

         if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
         {
            var blogContent = _contentService.GetArticleContent(RenderingContext.Current.Rendering.DataSource);
            if (blogContent != null)
            {
               viewModel.Title = blogContent.Title;
               viewModel.Body = blogContent.Body;

               var comments = _commentService.GetComments(blogContent.Id.ToString());
               if (comments != null)
               {
                  foreach(var comment in comments)
                  {
                     viewModel.Comments.Add(new BlogCommentViewModel()
                     {
                        Name = comment.Name,
                        Comment = comment.Comment,
                        DatePosted = comment.DatePosted
                     });
                  }
               }
            }
         }  

         return View(viewModel);
      }
   }
}