using StudentManagement.Domain;

using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.WPFCore.DataProvider
{
    public interface IStudentDataProvider
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(Guid studentId);
        Guid SaveStudentData(Student student);
        bool DeleteStudentData(Guid studentId);
    }
}
