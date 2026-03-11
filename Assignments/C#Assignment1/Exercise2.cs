using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise2
    {
        static void Main(String[] args)
        {
            Console.Write("Enter distance in kilometers: ");
            double km = Convert.ToDouble(Console.ReadLine());

            double meters = km * 1000;

            Console.WriteLine("Distance in meters = " + meters);
            Console.ReadLine();
        }
    }
}
