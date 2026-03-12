using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise6
    {
        static void Main(string[] args)
        {
            Console.Write("Enter temperature in Fahrenheit: ");
            double f = Convert.ToDouble(Console.ReadLine());

            double c = (f - 32) * 5 / 9;

            Console.WriteLine("Temperature in Celsius = " + c);
        }
    }
}
