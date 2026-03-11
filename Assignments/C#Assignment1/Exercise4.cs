using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise4
    {
        static void Main(String[] args)
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num % 2 == 0)
                Console.WriteLine("Number is Even");
            else
                Console.WriteLine("Number is Odd");

            Console.ReadLine();
        }
    }
}
