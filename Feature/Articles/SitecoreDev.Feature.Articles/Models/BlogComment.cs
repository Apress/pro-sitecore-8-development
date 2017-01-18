using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreDev.Feature.Articles.Models
{
   public class BlogComment : IComment
   {
      public string Name { get; set; }
      public string Comment { get; set; }
      public DateTime DatePosted { get; set; }
   }
}