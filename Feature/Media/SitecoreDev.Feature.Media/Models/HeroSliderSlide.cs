using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Feature.Media.Models
{
  public class HeroSliderSlide : CmsEntity, IHeroSliderSlide
  {
    public Image Image { get; set; }
  }
}