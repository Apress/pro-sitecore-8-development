using Sitecore.Mvc.ExperienceEditor.Presentation;
using System.IO;

namespace SitecoreDev.Foundation.SitecoreExtensions.RenderingWrapper
{
   public class EditorRenderingWrapper : Wrapper
   {
      public EditorRenderingWrapper(TextWriter writer, IMarker marker)
          : base(writer, marker)
      {
      }
   }
}