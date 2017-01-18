using SitecoreDev.Feature.Media.Models;
using SitecoreDev.Foundation.Repository.Content;

namespace SitecoreDev.Feature.Media.Services
{
  public class SitecoreMediaContentService : IMediaContentService
  {
    private readonly IContentRepository _repository;

    public SitecoreMediaContentService(IContentRepository repository)
    {
      _repository = repository;
    }

    public IHeroSlider GetHeroSliderContent(string contentGuid)
    {
      if (string.IsNullOrEmpty(contentGuid))
        return null;

      var heroSlider = _repository.GetContentItem<IHeroSlider>(contentGuid);
      heroSlider.Slides = _repository.GetChildren<IHeroSliderSlide>(contentGuid);
      return heroSlider;
    }
  }
}