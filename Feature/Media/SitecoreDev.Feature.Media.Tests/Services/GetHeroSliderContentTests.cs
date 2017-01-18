using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SitecoreDev.Foundation.Repository.Content;
using FluentAssertions;
using Ploeh.AutoFixture;
using SitecoreDev.Feature.Media.Models;
using SitecoreDev.Feature.Media.Services;

namespace SitecoreDev.Feature.Media.Tests.Services
{
  [TestClass]
  public class GetHeroSliderContentTests : TestBase<ServiceTestHarness>
  {
    [TestMethod]
    public void GetHeroSliderContentSuccessful()
    {
      //Arrange
      var heroSlide = _testHarness.Fixture
        .Build<HeroSlider>()
        .Without(x => x.Slides)
        .Create();
      var children = _testHarness.Fixture
        .CreateMany<HeroSliderSlide>()
        .ToList();

      _testHarness.ContentRepository
        .Setup(x => x.GetContentItem<IHeroSlider>(It.IsAny<string>()))
        .Returns(heroSlide)
        .Verifiable();
      _testHarness.ContentRepository
        .Setup(x => x.GetChildren<IHeroSliderSlide>(It.IsAny<string>()))
        .Returns(children)
        .Verifiable();

      //Act
      var result = _testHarness.ContentService.GetHeroSliderContent("123");

      //Assert
      _testHarness.ContentRepository.Verify();
      result.Should().NotBeNull();
      result.Slides.Should().NotBeNullOrEmpty();
      result.Slides.Count().Should().Be(children.Count());
      var slides = result.Slides.ToList();
      foreach (var slide in slides)
        slide.Image.Should().NotBeNull();
    }

    [TestMethod]
    public void GetHeroSliderContentEmptyContentGuid()
    {
      //Arrange
      var contentGuidNullException = new ArgumentNullException("contentGuid");
      var parentGuidNullException = new ArgumentNullException("parentGuid");

      _testHarness.ContentRepository
        .Setup(x => x.GetContentItem<IHeroSlider>(String.Empty))
        .Throws(contentGuidNullException);
      _testHarness.ContentRepository
        .Setup(x => x.GetChildren<IHeroSliderSlide>(String.Empty))
        .Throws(parentGuidNullException);

      //Act
      var result = _testHarness.ContentService.GetHeroSliderContent(String.Empty);

      //Assert
      result.Should().BeNull();
    }
  }
}