using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;

namespace SitecoreDev.Foundation.Ioc.Pipelines.InitializeContainer
{
  public class InitializeContainer
  {
    public void Process(PipelineArgs args)
    {
      Log.Info("Initializing IoC container...", this);

      var container = new Container();
      container.Options.ConstructorResolutionBehavior = new DefaultFirstConstructorBehavior();

      var containerArgs = new InitializeContainerArgs(container);
      CorePipeline.Run("initializeContainer", containerArgs);

      var assemblies = AppDomain.CurrentDomain.GetAssemblies()
          .Where(a => a.FullName.StartsWith("SitecoreDev.Feature.") || a.FullName.StartsWith("SitecoreDev.Foundation."));
      container.RegisterMvcControllers(assemblies.ToArray());
      container.RegisterMvcIntegratedFilterProvider();

      DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
    }
  }

  public class DefaultFirstConstructorBehavior : IConstructorResolutionBehavior
  {
    public ConstructorInfo GetConstructor(Type serviceType, Type implementationType)
    {
      var constructors = implementationType.GetConstructors();
      if (constructors.Any())
      {
        return (
            from ctor in constructors
            orderby ctor.GetParameters().Length ascending
            select ctor)
            .First();
      }

      return null;
    }
  }
}