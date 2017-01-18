using SitecoreDev.Feature.Media.Models;

namespace SitecoreDev.Feature.Media.Services
{
   public interface IMediaContentService
   {
      IHeroSlider GetHeroSliderContent(string contentGuid);
   }
}