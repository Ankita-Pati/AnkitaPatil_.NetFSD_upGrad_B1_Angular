using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise5
    {
        static void Main(String[] args)
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            if (num1 > num2)
                Console.WriteLine("Highest number is: " + num1);
            else
                Console.WriteLine("Highest number is: " + num2);

            Console.ReadLine();
        }
    }
}
