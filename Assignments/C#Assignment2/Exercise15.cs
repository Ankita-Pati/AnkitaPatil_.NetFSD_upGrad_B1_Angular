using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise15
    {
        static void Main(string[] args)
        {
            int[] marks = new int[10];
            int total = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter mark: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
                total += marks[i];
            }

            Array.Sort(marks);

            Console.WriteLine("Total = " + total);
            Console.WriteLine("Average = " + total / 10);
            Console.WriteLine("Minimum = " + marks[0]);
            Console.WriteLine("Maximum = " + marks[9]);

            Console.WriteLine("Ascending Order:");
            foreach (int m in marks) Console.WriteLine(m);

            Console.WriteLine("Descending Order:");
            Array.Reverse(marks);
            foreach (int m in marks) Console.WriteLine(m);
        }
    }
}
