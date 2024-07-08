using Microsoft.AspNetCore.Http.HttpResults;
using repository_pattern.Data;
using repository_pattern.DTO;
using repository_pattern.Model;

namespace repository_pattern.Services
{
    public class StudentService : IStudent
    {
        private readonly DataContext _dataContext;
        public StudentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddStudent(AddStudentDTO addStudentDTO)
        {
            Student student = new Student();
            student.Name = addStudentDTO.FirstName;
            student.LastName = addStudentDTO.LastName;
            student.Email = addStudentDTO.Email;
            student.StudentId = Guid.NewGuid();

            var Add = _dataContext.Students.Add(student);
            _dataContext.SaveChanges();
        }

        public bool DeleteStudentById(Guid id)
        {
            Student student = _dataContext.Students.Find(id);
            if (student == null )
            {
                return false;
            }
            _dataContext.Remove(student);
            _dataContext.SaveChanges();

            return true;
        }

        public IEnumerable<Student> GetAllStudents()
        {
           return _dataContext.Students.AsEnumerable();
        }

        public Student GetstudentById(Guid id)
        {
            return _dataContext.Students.Find(id);
        }

        public ShowStudentDTO UpdateStudentById(Student student)
        {
            var FindStudent = GetstudentById(student.StudentId);
            if (FindStudent == null )
            {
                return null;
                    
            }
            FindStudent.Name = student.Name;
            _dataContext.SaveChanges();
            ShowStudentDTO showStudentDTO = new ShowStudentDTO();
            showStudentDTO.FirstName = student.Name;
            return showStudentDTO;
        }
    }
}
