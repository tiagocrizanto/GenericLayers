using Example.DomainServices;
using Example.Infra.Data;
using Example.Infra.Data.Context;
using Example.Infra.Data.UnitOfWork;
using Example.Shared.Data.Repository;
using Example.Shared.DomainServices;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infra.IoC
{
    public class Bootstrapper
    {
        public static void Register(Container container)
        {
            //Repository
            container.Register(typeof(IBaseRepository<,>), (typeof(BaseRepository<,>)), Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);

            //Services
            container.Register(typeof(IBaseService<,>), (typeof(BaseService<,>)), Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<MyContext>(Lifestyle.Scoped);
        }
    }
}
