using SitecoreDev.Feature.Search.Services;
using SitecoreDev.Foundation.Ioc.Pipelines.InitializeContainer;

namespace SitecoreDev.Feature.Search.Pipelines.InitializeContainer
{
   public class RegisterDependencies
   {
      public void Process(InitializeContainerArgs args)
      {
         args.Container.Register<ISearchService, SitecoreSearchService>();
      }
   }
}