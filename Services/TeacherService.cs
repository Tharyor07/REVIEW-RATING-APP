using Microsoft.AspNetCore.Identity;
using repository_pattern.Data;
using repository_pattern.DTO;
using repository_pattern.Model;

namespace repository_pattern.Services
{
    public class TeacherService : ITeacher
    {
        private readonly DataContext _dataContext;
        public TeacherService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddTeacher(AddTeacherDTO addTeacherDTO,string userId)
        {
            Teacher teacher = new Teacher(addTeacherDTO,userId);
            var add = _dataContext.Teacher.Add(teacher);
            _dataContext.SaveChanges();
        }

        public bool DeleteTeacherById(Guid id)
        {
            Teacher teacher = _dataContext.Teacher.Find(id);
            if (teacher == null)
            {
                return false;
            }
            _dataContext.Remove(teacher);
            _dataContext.SaveChanges();

            return true;
        }

        public Teacher GetTeacherById(Guid id)
        {
            return _dataContext.Teacher.Find(id);
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return _dataContext.Teacher.AsEnumerable();
        }

        public Teacher UpdateTeacherById(Teacher teacher)
        {
            var FindTeacher = GetTeacherById(teacher.TeacherId);
          
            if (FindTeacher == null)
            {
                return null; 
            }
            FindTeacher.Name = teacher.Name;
            FindTeacher.Rating = teacher.Rating;
            _dataContext.SaveChanges();

            return FindTeacher;


        }
    }
}
