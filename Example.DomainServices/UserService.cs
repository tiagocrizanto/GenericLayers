using Example.Domain;
using Example.Infra.Data;
using Example.Infra.Data.UnitOfWork;
using Example.Shared.Data.Repository;
using Example.Shared.DomainServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DomainServices
{
    public class UserService : BaseService<User, DbContext>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public UserService(IBaseRepository<User, DbContext> baseRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
            : base (baseRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
    }
}
