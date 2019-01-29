using ArrayManipulation.Repository;
using ArrayManipulation.Services;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace ArrayManipulation
{
    public class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ArrayManipulationRepository>().As<IArrayManipulationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ReverseService>().As<IReverseService>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteService>().As<IDeleteService>().InstancePerLifetimeScope();
            builder.RegisterType<ConversionService>().As<IConversionService>().InstancePerLifetimeScope();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}