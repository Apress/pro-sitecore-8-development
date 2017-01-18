using SitecoreDev.Foundation.Ioc.Pipelines.InitializeContainer;
using SitecoreDev.Foundation.Repository.Content;
using SitecoreDev.Foundation.Repository.Context;
using SitecoreDev.Foundation.Repository.Search;

namespace SitecoreDev.Foundation.Repository.Pipelines.InitializeContainer
{
   public class RegisterDependencies
   {
      public void Process(InitializeContainerArgs args)
      {
         args.Container.Register<IContentRepository, SitecoreContentRepository>();
         args.Container.Register<IContextWrapper, SitecoreContextWrapper>();
         args.Container.Register<ISearchRepository, SitecoreSearchRepository>();
    }
   }
}
