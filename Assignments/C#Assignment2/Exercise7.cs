using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise7
    {
        static void Main(string[] args)
        {
            double total = 0;

            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Enter product number: ");
                int p = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter quantity: ");
                int q = Convert.ToInt32(Console.ReadLine());

                double price = 0;

                if (p == 1) price = 22.5;
                else if (p == 2) price = 44.50;
                else if (p == 3) price = 9.98;

                total += price * q;
            }

            Console.WriteLine("Total Price = " + total);
        }
    }
}
