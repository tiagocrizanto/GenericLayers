using Example.Shared.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infra.Data
{
    public interface IUserRepository : IBaseRepository<Domain.User, DbContext>
    {
    }
}
