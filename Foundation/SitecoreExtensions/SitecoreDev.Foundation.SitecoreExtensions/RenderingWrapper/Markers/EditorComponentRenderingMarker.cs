using Sitecore.Mvc.ExperienceEditor.Presentation;

namespace SitecoreDev.Foundation.SitecoreExtensions.RenderingWrapper.Markers
{
   public class EditorComponentRenderingMarker : IMarker
   {
      private string _componentName;
      public EditorComponentRenderingMarker(string componentName)
      {
         _componentName = componentName;
      }
      public string GetStart()
      {
         string formatstring = "<div class=\"component-wrapper {0}\"><span class=\"wrapper-header\">{1}</span><div class=\"component-content clearfix\">";
         return string.Format(formatstring, _componentName.Replace(" ", string.Empty), _componentName);
      }
      public string GetEnd()
      {
         return "</div></div>";
      }
   }
}