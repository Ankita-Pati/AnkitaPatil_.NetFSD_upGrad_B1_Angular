using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise3
    {
        static void Main(String[] args)
        {
            double sum = 0;

            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter number " + i + ": ");
                sum += Convert.ToDouble(Console.ReadLine());
            }

            double average = sum / 5;

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Average = " + average);
            Console.ReadLine();
        }
    }
}
