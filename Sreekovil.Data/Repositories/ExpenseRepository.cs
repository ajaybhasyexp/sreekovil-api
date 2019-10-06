using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace COSMO.Data.Repositories
{
    /// <summary>
    /// The repository class for expenses.
    /// </summary>
    public class ExpenseRepository : GenericRepository<User>, IExpenseRepository
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        private IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("COSMODev"));
            }
        }

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public ExpenseRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }
    }
}
