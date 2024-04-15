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
        public TeacherController(ITeacher teacher)
        {
            _teacher = teacher;
        }
        [HttpPost("Create")]
        public IActionResult AddTeacher(AddTeacherDTO teacher)
        {
            _teacher.AddTeacher(teacher);
            return Ok("successful");
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
