using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace COSMO.Data.Repositories
{
    public class BatchRepository : GenericRepository<Batch>, IBatchRepository
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public BatchRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }

        /// <summary>
        /// The common property to get connection.
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("COSMODev"));
            }
        }

        #region Public Methods

        public List<Batch> GetAssignedBatches(int branchId, int courseId)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<Batch>("getbatches", new { branchId = branchId, courseid = courseId },
                commandType: CommandType.StoredProcedure).ToList();
            }
        }

        #endregion
    }
}
