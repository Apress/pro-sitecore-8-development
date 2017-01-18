using System.Collections.Specialized;

namespace SitecoreDev.Foundation.Repository.Context
{
  public interface IContextWrapper
  {
    string Datasource { get; }
    bool IsExperienceEditor { get; }
    string CurrentItemPath { get; }
    string GetParameterValue(string key);
  }
}