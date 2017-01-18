using System.Collections.Generic;
using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;
using Sitecore.Data.Fields;

namespace SitecoreDev.Feature.Search.Models
{
  public class BlogCategoriesComputedField : IComputedIndexField
  {
    public string FieldName { get; set; }

    public string ReturnType { get; set; }

    public object ComputeFieldValue(IIndexable indexable)
    {
      var indexItem = indexable as SitecoreIndexableItem;
      if (indexItem == null)
        return null;

      var item = indexItem.Item;
      var children = item.GetChildren();

      var componentsFolder = children.FirstOrDefault(x => x.TemplateID == ID.Parse("{B0A97186-187F-4DCB-BABA-4096ABCD70B2}"));
      if (componentsFolder == null)
        return null;

      var childContent = componentsFolder.GetChildren();
      var blogContent = childContent.FirstOrDefault(x => x.TemplateID == ID.Parse("{D45EAC17-5DC2-4AF2-8FCD-A4896E5CA07F}"));
      if (blogContent == null)
        return null;

      MultilistField categories = blogContent.Fields["Categories"];
      var categoryNameList = new List<string>();
      foreach(var id in categories.TargetIDs)
      {
        var category = blogContent.Database.GetItem(id);
        if (categories != null)
          categoryNameList.Add(category.DisplayName);
      }

      return categoryNameList;
    }
  }
}