using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace COSMO.Data.Repositories
{
    public class IncomeHeadRepository : GenericRepository<IncomeHead>, IIncomeHeadRepository
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
        public IncomeHeadRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }
    }
}
