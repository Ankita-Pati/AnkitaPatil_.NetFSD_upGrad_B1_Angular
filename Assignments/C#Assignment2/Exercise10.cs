using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise10
    {
        static void Main(string[] args)
        {
            int a = 0, b = 1;

            while (a <= 40)
            {
                Console.WriteLine(a);
                int c = a + b;
                a = b;
                b = c;
            }
        }
    }
}
