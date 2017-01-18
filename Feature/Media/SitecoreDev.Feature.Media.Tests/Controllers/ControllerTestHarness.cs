using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc;
using Moq;
using Ploeh.AutoFixture;
using SimpleInjector;
using SitecoreDev.Feature.Media.Controllers;
using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Foundation.Repository.Context;

namespace SitecoreDev.Feature.Media.Tests.Controllers
{
  public class ControllerTestHarness : TestHarnessBase
  {
    private Mock<IContextWrapper> _mockContextWrapper;
    public Mock<IContextWrapper> ContextWrapper
    {
      get
      {
        if (_mockContextWrapper == null)
          _mockContextWrapper = Mock.Get(_container.GetInstance<IContextWrapper>());
        return _mockContextWrapper;
      }
    }

    private Mock<IMediaContentService> _mockContentService;
    public Mock<IMediaContentService> ContentService
    {
      get
      {
        if (_mockContentService == null)
          _mockContentService = Mock.Get(_container.GetInstance<IMediaContentService>());
        return _mockContentService;
      }
    }

    private Mock<IGlassHtml> _mockGlassHtml;
    public Mock<IGlassHtml> GlassHtml
    {
      get
      {
        if (_mockGlassHtml == null)
          _mockGlassHtml = Mock.Get(_container.GetInstance<IGlassHtml>());
        return _mockGlassHtml;
      }
    }

    private MediaController _controller;
    public MediaController Controller
    {
      get
      {
        if (_controller == null)
          _controller = _container.GetInstance<MediaController>();
        return _controller;
      }
    }

    public ControllerTestHarness()
    {
      InitializeContainer();

      _fixture = new Fixture();

      ContextWrapper
         .SetupGet(rc => rc.Datasource)
         .Returns(Fixture.Create<string>());
    }

    protected void InitializeContainer()
    {
      _container.Register<IContextWrapper>(() => new Mock<IContextWrapper>().Object, Lifestyle.Singleton);
      _container.Register<IMediaContentService>(() => new Mock<IMediaContentService>().Object, Lifestyle.Singleton);
      _container.Register<IGlassHtml>(() => new Mock<IGlassHtml>().Object, Lifestyle.Singleton);
      _container.Register<MediaController>(Lifestyle.Transient);
    }
  }
}
