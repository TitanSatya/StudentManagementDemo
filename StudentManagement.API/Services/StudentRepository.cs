using StudentManagement.API.DBContexts;
using StudentManagement.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext _appDBContext;
        public StudentRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(AppDBContext));
        }
        public bool DeleteStudentData(Guid studentId)
        {
            Student student = _appDBContext.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                _appDBContext.Students.Remove(student);

                _appDBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _appDBContext.Students;
        }

        public Student GetStudent(Guid studentId)
        {
            return _appDBContext.Students.FirstOrDefault(x => x.StudentId == studentId);
        }
        /// <summary>
        /// Save Student Data
        /// </summary>
        /// <param name="student">Student Parameter</param>
        /// <returns></returns>
        public Guid SaveStudentData(Student student)
        {
           _= student ?? throw new Exception("Student is null");
            var newStudentId = Guid.NewGuid();
            student.StudentId = newStudentId;
            _appDBContext.Students.Add(student);
            _appDBContext.SaveChanges();
            return newStudentId;
        }
    }
}
