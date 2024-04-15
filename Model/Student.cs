using System.ComponentModel.DataAnnotations;

namespace repository_pattern.Model
{
    public class Student : Person
    {
        [Key]
        public Guid StudentId{ get; set; }
    }
}
