using Example.Domain;
using Example.Shared.DomainServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DomainServices
{
    public interface IUserService : IBaseService<User, DbContext>
    {
    }
}
