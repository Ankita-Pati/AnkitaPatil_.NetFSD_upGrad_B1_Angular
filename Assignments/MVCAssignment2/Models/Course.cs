namespace MVCAssignment2.Models
{
    public class Course
    {
            public int CourseId { get; set; }
            public string ?CourseName { get; set; }

            // Foreign Key
            public int StudentId { get; set; }
            public Student ?Student { get; set; }
    }
}
