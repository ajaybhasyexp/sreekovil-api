using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace COSMO.Data.Repositories
{
    public class CourseFeeRepository : GenericRepository<CourseFee>, ICourseFeeRepository
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// The common property to get connection.
        /// </summary>
        private IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("COSMODev"));
            }
        }

        public CourseFeeRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }

        public List<CourseFee> GetCourseFeeVM(int branchId)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<CourseFee>("getcoursefee", new { branchId = branchId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<CourseFee> GetCourseFee(int branchId, int courseId)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<CourseFee>("getfeestructureforbranchcourse", new { branchid = branchId, courseid = courseId },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
