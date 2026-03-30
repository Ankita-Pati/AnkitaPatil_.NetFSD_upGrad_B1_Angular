using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MVCAssignment2.Models
{
    //public class Student
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public string Email { get; set; }

    //    // Navigation Property
    //    public List<Course> Courses { get; set; }
    //}

    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string ?Name { get; set; }

        [Range(18, 60 ,ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string ?Email { get; set; }
    }
}
