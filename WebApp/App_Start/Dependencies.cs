using System.Reflection;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using Entities;
using Entities.Repositories.Membership;
using Repositories;
using Repositories.Repositories.Membership;
using Services.Common;

namespace WebApp
{
    public static class Dependencies
    {
        public static IContainer Configure(ContainerBuilder builder, EntityContext dbcontext)
        {
            //var dbcontext = new EntityContext();
            //builder.Register(x => dbcontext.ObjectContext).As<IDbContext>();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.Register(x => DatabaseFactory.Get()).As<IDbContext>();
            //builder.RegisterType<EntityContext>().As<IComponentContext>();
            //builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<UnitOfWork>().As<IRepoFactory>();
            builder.RegisterType<UserRepo>().As<IUserRepo>();
            builder.RegisterType<RoleRepo>().As<IRoleRepo>();
            builder.RegisterAssemblyTypes(typeof(BaseService).Assembly)
                .Where(x => typeof(IService).IsAssignableFrom(x))
                .AsSelf()
                .AsImplementedInterfaces();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            return builder.Build();
        }
    }
}