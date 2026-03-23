namespace C_LINQAssignment9
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Student
    {
        public int Id;
        public string Name;
        public int Age;
        public int Marks;
    }

    internal class Exercise1
    {
        static void Main()
        {
            List<Student> students = new List<Student>
        {
            new Student{Id=1, Name="Amit", Age=20, Marks=80},
            new Student{Id=2, Name="Ravi", Age=22, Marks=70},
            new Student{Id=3, Name="Kiran", Age=18, Marks=90},
            new Student{Id=4, Name="Anil", Age=25, Marks=60}
        };

            // 1. Marks > 75
            var highMarks = students.Where(s => s.Marks > 75);

            // 2. Age between 18 and 25
            var ageFilter = students.Where(s => s.Age >= 18 && s.Age <= 25);

            // 3. Sort by Marks descending
            var sorted = students.OrderByDescending(s => s.Marks);

            // 4. Select Name and Marks
            var selected = students.Select(s => new { s.Name, s.Marks });

            foreach (var s in selected)
                Console.WriteLine($"{s.Name} - {s.Marks}");
        }
    }
}
