using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Sreekovil.Data.Abstractions.Repositories;
using Sreekovil.Models.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Sreekovil.Data.Repositories
{
    /// <summary>
    /// THe user repository.
    /// </summary>
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public UserRepository(IConfiguration config)
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
                return new MySqlConnection(_config.GetConnectionString("SreekovilDev"));
            }
        }


        /// <summary>
        /// Gets the user using username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string userName, string password)
        {
            var sqlQuery = Queries.GetUserByUname;
            sqlQuery = string.Format(sqlQuery, userName, password);
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = conn.Query<User>(sqlQuery);
                return result.FirstOrDefault();
            }
        }

        public List<User> GetAll(int branchId)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<User>("getusers", new { branchid = branchId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
