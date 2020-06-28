using StudentManagement.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(Guid studentId);
        Guid SaveStudentData(Student student);
        bool DeleteStudentData(Guid studentId);
    }
}
