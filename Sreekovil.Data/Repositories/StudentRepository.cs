using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace COSMO.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRespository
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

        public StudentRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }

        public List<Student> GetAllVM(int branchId)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<Student>("getStudents", new { branchid = branchId },
                commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Source> GetSources()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.GetAll<Source>().ToList();
            }
        }

        public List<Qualification> GetQualifications()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.GetAll<Qualification>().ToList();
            }
        }

        public List<Profession> GetProfessions()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.GetAll<Profession>().ToList();
            }
        }
    }
}
