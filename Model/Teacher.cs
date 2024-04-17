using repository_pattern.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace repository_pattern.Model
{
    
    public class Teacher : Person
    {
        public Teacher(AddTeacherDTO addTeacherDTO, string userId)
        {
            TeacherId = Guid.NewGuid();
            Rating = 5;
            Name = addTeacherDTO.Name;
            UserId = userId;  
        }
        public Teacher()
        {
           
        }
        [Key]
        public Guid TeacherId { get; set; }
        public string UserId { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public double Rating { get; set; }
        List<Review> Reviews { get; set; }
    }
   
}
