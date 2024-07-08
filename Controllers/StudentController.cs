using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository_pattern.DTO;
using repository_pattern.Model;
using repository_pattern.Services;

namespace repository_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        private readonly IAuth _authService;
        public StudentController(IStudent student, IAuth authService)
        {
                _student = student;
            _authService = authService;
        }
      
     

        [HttpPost("Create")]
        public IActionResult AddStudent(AddStudentDTO student)
        {
            _student.AddStudent(student);
            
            return Ok("successful");
        }


      [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginUserDTO student)
        {
            var user = await _authService.FindUserByUsername("email");
            if (user == null)
            {
                return NotFound();
            }
            var result = await _authService.LoginUser(student, user);
            if (result.Item1 == true)
            {
                return Ok(result.Item2);
            }
       
            return BadRequest();
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
            var students = _student.GetAllStudents();
            return Ok(students);
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
