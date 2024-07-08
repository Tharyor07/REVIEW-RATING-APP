using repository_pattern.DTO;
using System.ComponentModel.DataAnnotations;

namespace repository_pattern.Model
{
    public class Student : Person
    {
        public Student()
        {
        }

        public Student(AddStudentDTO addStudentDTO)
        {
        }
        [Key]
        public Guid StudentId { get; set; }

    }
}
