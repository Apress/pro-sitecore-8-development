using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Feature.Media.Models
{
  public class HeroSlider : CmsEntity, IHeroSlider
  {
    public IEnumerable<IHeroSliderSlide> Slides { get; set; }
  }
}