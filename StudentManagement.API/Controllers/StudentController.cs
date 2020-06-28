using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

using StudentManagement.API.Services;
using StudentManagement.Domain;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet()]
        [HttpHead()]
        public ActionResult GetAllStudents()
        {
            var allStudents = _studentRepository.GetAllStudents();
            return Ok(allStudents);
        }
        [HttpGet("id={studentId}")]
        public ActionResult GetStudent(Guid studentId)
        {
            var student = _studentRepository.GetStudent(studentId);
            return Ok(student);
        }
        [HttpPost()]
        public ActionResult SaveStudent(Student student)
        {
            var id = _studentRepository.SaveStudentData(student);
            return Ok(id);
        }
        [HttpDelete("id={studentId}")]
        public ActionResult DeleteStudent(Guid studentId)
        {
            var result =_studentRepository.DeleteStudentData(studentId);
            return Ok(result);
        }
    }
}
