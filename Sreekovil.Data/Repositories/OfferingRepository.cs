using Dapper;
using Microsoft.Extensions.Configuration;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sreekovil.Data.Repositories
{
    public class OfferingRepository : GenericRepository<Offering>, IOfferingRepository
    {
        #region Constructor

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public OfferingRepository(IConfiguration config)
            : base(config)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get offerings by temple id.
        /// </summary>
        /// <param name="templeId">The temple identifier.</param>
        /// <returns>A list of offerings based on the temple</returns>
        public List<Offering> GetOfferingsByTempleId(int templeId)
        {
            string query = string.Format(Queries.GetOfferingsByTempleId, templeId);
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<Offering>(query).ToList();

            }
        }

        #endregion

    }
}
