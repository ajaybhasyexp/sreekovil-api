using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Business.Abstractions
{
    public interface IStudentService
    {
        Student Save(Student student);

        List<Student> GetAll(int branchId);

        Student Get(int studentId);

        List<Source> GetSources();

        List<Qualification> GetQualifications();

        List<Profession> GetProfessions();

        void Delete(Student student);

    }
}
