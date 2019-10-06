using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace COSMO.Data.Repositories
{
    public class ExpenseHeadRepository : GenericRepository<ExpenseHead>, IExpenseHeadRepository
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

        public ExpenseHeadRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }
    }
}
