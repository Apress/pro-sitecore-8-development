using Glass.Mapper.Sc;
using SimpleInjector;
using SitecoreDev.Foundation.Ioc.Pipelines.InitializeContainer;

namespace SitecoreDev.Foundation.Orm.Pipelines.InitializeContainer
{
   public class RegisterDependencies
   {
      public void Process(InitializeContainerArgs args)
      {
         args.Container.Register<ISitecoreContext>(() => new SitecoreContext(), Lifestyle.Transient);
         args.Container.Register<IGlassHtml, GlassHtml>();
      }
   }
}