using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment3
{
    class Nurse
    {
        public int NurseId { get; set; }
        public string NurseName { get; set; }
        public string Department { get; set; }
    }
    internal class Exercise7
    {
        static void Main()
        {
            Nurse n = new Nurse
            {
                NurseId = 101,
                NurseName = "Anita",
                Department = "Emergency"
            };

            Console.WriteLine("Nurse Id: " + n.NurseId);
            Console.WriteLine("Nurse Name: " + n.NurseName);
            Console.WriteLine("Department: " + n.Department);
        }
    }
}
