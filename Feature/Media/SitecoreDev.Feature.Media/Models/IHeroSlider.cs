using System.Collections.Generic;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Feature.Media.Models
{
   public interface IHeroSlider : ICmsEntity
   {
      IEnumerable<IHeroSliderSlide> Slides { get; set; }
   }
}