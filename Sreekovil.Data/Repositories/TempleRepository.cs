using Sreekovil.Data.Abstractions.Repositories;
using Microsoft.Extensions.Configuration;
using Sreekovil.Models.Models;
using System.Data;
using Sreekovil.Models.DataContext;
using System.Linq;

namespace Sreekovil.Data.Repositories
{
    public class TempleRepository : GenericRepository<Temple>, ITempleRepository
    {


        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public TempleRepository(EFDataContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the temple entity based on the user id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A temple object</returns>
        public Temple GetTempleByUserId(int userId)
        {
            var temple = from tmpl in dbSet
                         join user in _context.Users
                         on tmpl.Id equals user.TempleId
                         where user.Id == userId
                         select tmpl;
            return temple.FirstOrDefault();
        }
    }
}
