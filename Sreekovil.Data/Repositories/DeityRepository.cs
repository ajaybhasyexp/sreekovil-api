using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System.Linq;
using Dapper;
using System.Collections.Generic;
using System.Text;

namespace Sreekovil.Data.Repositories
{
    public class DeityRepository : GenericRepository<Deity>, IDeityRepository
    {
        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public DeityRepository(IConfiguration config) : base(config)
        {

        }

        /// <summary>
        /// Get offerings by temple id.
        /// </summary>
        /// <param name="templeId">The temple identifier.</param>
        /// <returns>A list of offerings based on the temple</returns>
        public List<Deity> GetDietyById(int deityId)
        {
            string query = string.Format(Queries.GetDeityByDietyId, deityId);
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<Deity>(query).ToList();
            }
        }
    }
}
