using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Foundation.Ioc.Pipelines.InitializeContainer;

namespace SitecoreDev.Feature.Media.Pipelines.InitializeContainer
{
   public class RegisterDependencies
   {
      public void Process(InitializeContainerArgs args)
      {
         args.Container.Register<IMediaContentService, SitecoreMediaContentService>();
      }
   }
}