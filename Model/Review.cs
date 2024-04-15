using System.ComponentModel.DataAnnotations.Schema;

namespace repository_pattern.Model
{
    public class Review
    {
        public Guid Id { get; set; }
        public double Rating { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher  { get; set; }       
    }
}

