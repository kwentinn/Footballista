using Autofac;
using Footballista.Cqrs;
using Footballista.Cqrs.Commands;
using Footballista.Cqrs.Queries;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;

namespace Footballista.Wasm.Server.Configuration.AutofacModules
{
    internal class MediatRModule : Module
    {
        private readonly Assembly[] _assemblies = new Assembly[]
        {
            FootballistaCqrsQueries.Assembly,
            FootballistaCqrsCommands.Assembly,
            FootballistaCqrs.Assembly
        };

        protected override void Load(ContainerBuilder builder)
        {
            RegisterMediatR(builder);
            RegisterMediatorWrapper(builder);

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                IComponentContext c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            RegisterHandlersFromAssemblies(builder);
        }

        private void RegisterHandlersFromAssemblies(ContainerBuilder builder)
        {
            // finally register our custom code (individually, or via assembly scanning)
            // - requests & handlers as transient, i.e. InstancePerDependency()
            // - pre/post-processors as scoped/per-request, i.e. InstancePerLifetimeScope()
            // - behaviors as transient, i.e. InstancePerDependency()
            builder
                .RegisterAssemblyTypes(_assemblies)
                .Where(t => !t.IsInterface && t.Name.EndsWith("Handler"))
                .AsImplementedInterfaces(); // via assembly scan
        }
        private static void RegisterMediatorWrapper(ContainerBuilder builder)
        {
            builder
                .RegisterType<MediatorWrapper>()
                .As<IMediatorWrapper>()
                .InstancePerLifetimeScope();
        }
        private static void RegisterMediatR(ContainerBuilder builder)
        {
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();
        }
    }
}
