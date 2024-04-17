using repository_pattern.DTO;
using repository_pattern.Model;

namespace repository_pattern.Services
{
    public interface ITeacher
    {
        //Return type Method_Name
        void AddTeacher(AddTeacherDTO addTeacherDTO,string userId);
        Teacher GetTeacherById(Guid id);
        IEnumerable<Teacher> GetTeachers();
        bool DeleteTeacherById(Guid id);
        Teacher UpdateTeacherById(Teacher teacher);


    }
}
