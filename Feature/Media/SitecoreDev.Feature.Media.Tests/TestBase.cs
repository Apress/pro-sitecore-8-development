using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SitecoreDev.Feature.Media.Tests
{
  public abstract class TestBase<T> where T : ITestHarness, new()
  {
    protected T _testHarness;

    [TestInitialize]
    public void Setup()
    {
      _testHarness = new T();
    }
  }
}
