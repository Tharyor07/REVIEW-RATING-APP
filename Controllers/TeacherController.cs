using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repository_pattern.Data;
using repository_pattern.DTO;
using repository_pattern.Model;
using repository_pattern.Services;

namespace repository_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _teacher;
        private readonly IAuth _authService;

        public TeacherController(ITeacher teacher, IAuth authService)
        {
            _teacher = teacher;
            _authService = authService;
        }


        [HttpPost("Create")]
        public IActionResult AddTeacher(AddTeacherDTO teacher)
        {
            // Add Identity user
            // add user

            string userId = "";

            _teacher.AddTeacher(teacher, userId);
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


        [HttpDelete("delete")]
        public IActionResult DeleteTeacherById(Guid id)
        {
            bool teacher = _teacher.DeleteTeacherById(id);
            if (teacher == false)
            {
                return NotFound();
            }
            return Ok("successful");
        }


        [HttpGet("{id}")]
        public IActionResult GetTeacherById(Guid id)
        { 
            var FindTeacher = _teacher.GetTeacherById(id);
            if (FindTeacher == null)
            {
                return BadRequest();
            }
            return Ok(FindTeacher);
        }
        [HttpGet("all")]
        public IActionResult GetTeachers()
        {
            return Ok(_teacher.GetTeachers());
        }


        [HttpPut("update")]
        public IActionResult UpdateTeacherById(Teacher teacher)
        {
            var Update = _teacher.UpdateTeacherById(teacher);
            if (Update == null)
            {
                return BadRequest();
            }
            return Ok(Update);
        }

    }
}
