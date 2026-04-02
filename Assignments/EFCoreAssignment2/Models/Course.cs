using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string ?Title { get; set; }

        [Range(1, 10)]
        public int Credits { get; set; }

        public ICollection<Enrollment> ?Enrollments { get; set; }
    }
}

