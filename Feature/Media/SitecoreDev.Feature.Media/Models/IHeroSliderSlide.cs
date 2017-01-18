using Glass.Mapper.Sc.Fields;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Feature.Media.Models
{
   public interface IHeroSliderSlide : ICmsEntity
   {
      Image Image { get; }
   }
}