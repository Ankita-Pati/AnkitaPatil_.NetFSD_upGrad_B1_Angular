using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise5
    {
        static void Main(string[] args)
        {
            int even = 0, odd = 0;

            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter number: ");
                int num = Convert.ToInt32(Console.ReadLine());

                if (num % 2 == 0)
                    even++;
                else
                    odd++;
            }

            Console.WriteLine("Even count = " + even);
            Console.WriteLine("Odd count = " + odd);
        }
    }
}
