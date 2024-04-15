using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository_pattern.Model;
using repository_pattern.Services;

namespace repository_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        public StudentController(IStudent student)
        {
                _student = student;
        }
        [HttpPost("Create")]
        public IActionResult AddStudent(Student student)
        {
            _student.AddStudent(student);
            
            return Ok("successful");
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteStudentById(Guid id)
        {
            bool student = _student.DeleteStudentById(id);
            if (student == null)
            {
                return BadRequest();
            }
            return Ok("successful");
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentById(Guid id)
        {
            var FindStudent = _student.GetstudentById(id);
            if (FindStudent == null)
            {
                return BadRequest();
            }
            return Ok(FindStudent);
        }
        [HttpGet("all")]
        public IActionResult GetAllStudents()
        {
            return Ok(_student.GetAllStudents);
        }
        [HttpPut("update")]
        public IActionResult UpdateStudentById(Student student)
        {
            var update = _student.UpdateStudentById(student);
            if (update == null)
            {
                return NotFound();
            }
            return Ok(update);
        }
    }
    
}
