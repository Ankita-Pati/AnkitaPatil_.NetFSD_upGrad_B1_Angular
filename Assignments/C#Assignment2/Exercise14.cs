using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise14
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;

            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter number: ");
                int num = Convert.ToInt32(Console.ReadLine());

                if (num < min)
                    min = num;
            }

            Console.WriteLine("Smallest number = " + min);
        }
    }
}
