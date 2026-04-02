using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment2.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string ?Name { get; set; }

        [Required]
        [EmailAddress]
        public string ?Email { get; set; }

        public ICollection<Enrollment> ?Enrollments { get; set; }
    }
}
