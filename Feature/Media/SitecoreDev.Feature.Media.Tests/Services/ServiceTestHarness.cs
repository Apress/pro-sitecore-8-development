using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Ploeh.AutoFixture;
using SimpleInjector;
using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Foundation.Repository.Content;

namespace SitecoreDev.Feature.Media.Tests.Services
{
  public class ServiceTestHarness : TestHarnessBase
  {
    private Mock<IContentRepository> _contentRepository;
    public Mock<IContentRepository> ContentRepository
    {
      get
      {
        if (_contentRepository == null)
          _contentRepository = Mock.Get(_container.GetInstance<IContentRepository>());
        return _contentRepository;
      }
    }

    private IMediaContentService _contentService;
    public IMediaContentService ContentService
    {
      get
      {
        if (_contentService == null)
          _contentService = _container.GetInstance<IMediaContentService>();
        return _contentService;
      }
    }

    public ServiceTestHarness()
    {
      InitializeContainer();
      _fixture = new Fixture();
    }

    protected void InitializeContainer()
    {
      _container.Register<IContentRepository>(() => new Mock<IContentRepository>().Object, Lifestyle.Singleton);
      _container.Register<IMediaContentService, SitecoreMediaContentService>(Lifestyle.Transient);
    }
  }
}
