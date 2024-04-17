using repository_pattern.DTO;
using repository_pattern.Model;

namespace repository_pattern.Services
{
    public interface IStudent
    {
        void AddStudent(AddStudentDTO addStudentDTO);
        Student GetstudentById(Guid id);
        IEnumerable<Student> GetAllStudents();
        bool DeleteStudentById(Guid id);
        ShowStudentDTO UpdateStudentById(Student student);

    }
}
