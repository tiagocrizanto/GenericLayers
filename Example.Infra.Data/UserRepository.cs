using Example.Domain;
using Example.Infra.Data.Context;
using Example.Shared.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infra.Data
{
    public class UserRepository : BaseRepository<User, DbContext>, IUserRepository
    {
        private readonly MyContext _context;
        public UserRepository(MyContext context)
            : base(context)
        {

        }
    }
}
