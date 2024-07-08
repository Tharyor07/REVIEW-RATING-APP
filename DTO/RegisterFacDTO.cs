using System.ComponentModel.DataAnnotations;

namespace repository_pattern.DTO
{
    public class RegisterFacDTO 
    {

            [Required]
            [EmailAddress]
            [StringLength(50)]
            public string Email { get; set; }
            [Required]

            [StringLength(100)]
            public string FirstName { get; set; }
            [Required]
            [StringLength(100)]
            public string LastName { get; set; }
            [Required]
            [StringLength(100)]
            public string Course { get; set; }

    }
}
