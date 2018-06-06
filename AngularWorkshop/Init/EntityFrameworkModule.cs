using System;
using System.Linq;
using Autofac;
using Data;
using Model.Core;
using Module = Autofac.Module;

namespace AngularWorkshop.Init
{
    public class EntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.RegisterGeneric(typeof(EntityFrameworkRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly)
                .Where(
                    type =>
                        ImplementsInterface(typeof(IRepository<>), type) ||
                        type.Name.EndsWith("Repository")
                ).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<DbContextUnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<StoreContext>()
                .WithParameter("isMigration", false)
                .InstancePerLifetimeScope();
        }

        private bool ImplementsInterface(Type interfaceType, Type concreteType)
        {
            return
                concreteType.GetInterfaces().Any(
                    t =>
                        (interfaceType.IsGenericTypeDefinition && t.IsGenericType
                            ? t.GetGenericTypeDefinition()
                            : t) == interfaceType);
        }
    }
}
