using Sreekovil.Data.Abstractions.Repositories;
using Microsoft.Extensions.Configuration;
using Sreekovil.Models.Models;
using System.Data;
using Dapper;

namespace Sreekovil.Data.Repositories
{
    public class TempleRepository : GenericRepository<Temple>, ITempleRepository
    {


        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public TempleRepository(IConfiguration config)
                : base(config)
        {
        }

        /// <summary>
        /// Gets the temple entity based on the user id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>A temple object</returns>
        public Temple GetTempleByUserId(int userId)
        {
            string query = string.Format(Queries.GetTempleByUserId, userId);
            using (var conn = Connection)
            {
                conn.Open();
                return conn.QueryFirstOrDefault<Temple>(query);
            }
        }
    }
}
