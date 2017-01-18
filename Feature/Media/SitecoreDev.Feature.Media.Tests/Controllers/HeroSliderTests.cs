using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using Ploeh.AutoFixture;
using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Foundation.Repository.Context;
using Glass.Mapper.Sc;
using SitecoreDev.Feature.Media.Models;
using System.Linq.Expressions;
using System.Web;
using SitecoreDev.Feature.Media.Controllers;
using SitecoreDev.Feature.Media.ViewModels;

namespace SitecoreDev.Feature.Media.Tests.Controllers
{
  [TestClass]
  public class HeroSliderTests : TestBase<ControllerTestHarness>
  {
    [TestMethod]
    public void HeroSliderSuccessful()
    {
      //Arrange
      var content = _testHarness.Fixture
        .Build<HeroSlider>()
        .With(x => x.Slides, _testHarness.Fixture.CreateMany<HeroSliderSlide>().ToList())
        .Create();

      _testHarness.ContentService.Setup(x => x.GetHeroSliderContent(It.IsAny<string>()))
        .Returns(content)
        .Verifiable();

      _testHarness.ContextWrapper.Setup(x => x.GetParameterValue(It.IsAny<string>()))
        .Returns("500")
        .Verifiable();
      _testHarness.ContextWrapper.SetupGet(x => x.IsExperienceEditor)
        .Returns(true)
        .Verifiable();
      _testHarness.ContextWrapper.SetupGet(x => x.Datasource)
        .Returns(Guid.NewGuid().ToString())
        .Verifiable();

      _testHarness.GlassHtml.Setup(x => x.Editable(It.IsAny<IHeroSliderSlide>(), It.IsAny<Expression<Func<IHeroSliderSlide, object>>>(), It.IsAny<object>()))
        .Returns("test")
        .Verifiable();

      //Act
      var result = _testHarness.Controller.HeroSlider();

      //Assert
      result.Should().NotBeNull();
      result.Model.Should().BeOfType<HeroSliderViewModel>();
      var viewModel = result.Model as HeroSliderViewModel;
      viewModel.Should().NotBeNull();
      viewModel.HasImages.Should().BeTrue();
      viewModel.ImageCount.Should().Be(content.Slides.Count());
      viewModel.SlideInterval.Should().Be(500);
      viewModel.IsSliderIntervalSet.Should().BeTrue();
      viewModel.IsInExperienceEditorMode.Should().BeTrue();
      viewModel.ParentGuid.Should().Be(content.Id.ToString());
    }

    [TestMethod]
    public void HeroSliderEmptyDatasource()
    {
      //Arrange
      _testHarness.ContextWrapper.Setup(x => x.GetParameterValue(It.IsAny<string>()))
        .Returns("500")
        .Verifiable();
      _testHarness.ContextWrapper.SetupGet(x => x.IsExperienceEditor)
        .Returns(true)
        .Verifiable();
      _testHarness.ContextWrapper.SetupGet(x => x.Datasource)
        .Returns(String.Empty)
        .Verifiable();

      //Act
      var result = _testHarness.Controller.HeroSlider();

      //Assert
      result.Should().NotBeNull();
      result.Model.Should().BeOfType<HeroSliderViewModel>();
      var viewModel = result.Model as HeroSliderViewModel;
      viewModel.Should().NotBeNull();
      viewModel.HasImages.Should().BeFalse();
      viewModel.ImageCount.Should().Be(0);
      viewModel.SlideInterval.Should().Be(500);
      viewModel.IsSliderIntervalSet.Should().BeTrue();
      viewModel.IsInExperienceEditorMode.Should().BeTrue();
      viewModel.ParentGuid.Should().BeNullOrEmpty();
    }
  }
}
