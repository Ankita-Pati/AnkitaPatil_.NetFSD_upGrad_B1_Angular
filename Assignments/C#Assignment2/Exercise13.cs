using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise13
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter third number: ");
            int c = Convert.ToInt32(Console.ReadLine());

            int max = Math.Max(a, Math.Max(b, c));

            Console.WriteLine("Largest number = " + max);
        }
    }
}
