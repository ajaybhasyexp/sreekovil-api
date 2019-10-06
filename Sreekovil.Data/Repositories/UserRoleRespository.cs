using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.UserModule;
using Microsoft.Extensions.Configuration;

namespace COSMO.Data.Repositories
{
    public class UserRoleRespository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRespository(IConfiguration config)
            : base(config)
        {

        }
    }
}
