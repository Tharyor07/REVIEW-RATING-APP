using System.ComponentModel.DataAnnotations.Schema;

namespace repository_pattern.Model
{
    public class Person
    {
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string course { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
