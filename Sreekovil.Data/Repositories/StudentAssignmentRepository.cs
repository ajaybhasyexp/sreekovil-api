using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using COSMO.Models.ViewModel;
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
    public class StudentAssignmentRepository : GenericRepository<StudentAssignment>, IStudentAssignmentRepository
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

        public StudentAssignmentRepository(IConfiguration config) : base(config)
        {
            _config = config;
        }

        public List<StudentAssignment> GetAllVM(int branchId)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<StudentAssignment>("getStudentAssignments", new { branchid = branchId },
                commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Gets the list of students whose fees hasnt been paid.
        /// </summary>
        /// <returns>A list of Student objects that has the fees yet to pay.</returns>
        public List<StudentCourse> GetUnpaidStudents(int branchId)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<StudentCourse>("getunpaidstudents", new { branchid = branchId },
                commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public new StudentAssignment Save(StudentAssignment studentAssignment)
        {
            using (var conn = Connection)
            {
                conn.Open();
                if (studentAssignment.Id == 0)
                {
                    studentAssignment.CreatedDate = DateTime.Now;
                    studentAssignment.UpdatedDate = DateTime.Now;
                    if (studentAssignment.BatchAssignId == 0)
                    {
                        string query = string.Format(Queries.BatchAssignmentFetch, studentAssignment.CourseId, studentAssignment.BatchId, studentAssignment.BranchId);
                        var assignment = conn.QueryFirstOrDefault<BatchAssignment>(query);
                        if (assignment != null)
                        {
                            studentAssignment.BatchAssignId = assignment.Id;
                        }
                    }
                    conn.Insert(studentAssignment);
                }
                else
                {
                    studentAssignment.UpdatedDate = DateTime.Now;
                    conn.Update(studentAssignment);
                }

                return studentAssignment;
            }
        }       

    }
}
