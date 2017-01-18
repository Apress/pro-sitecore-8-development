using System;
using System.Linq;
using System.Collections.Specialized;
using Sitecore.Mvc.Presentation;

namespace SitecoreDev.Foundation.Repository.Context
{
  public class SitecoreContextWrapper : IContextWrapper
  {
    public string Datasource => RenderingContext.Current.Rendering.DataSource;
    public bool IsExperienceEditor => Sitecore.Context.PageMode.IsExperienceEditor;

    public string CurrentItemPath => Sitecore.Context.Item.Paths.FullPath;

    public string GetParameterValue(string key)
    {
      var value = String.Empty;
      var parameters = RenderingContext.Current.Rendering.Parameters;
      if (parameters != null && parameters.Count() > 0)
        value = parameters[key];
      return value;
    }
  }
}