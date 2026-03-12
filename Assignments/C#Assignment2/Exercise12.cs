using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise12
    {
        static void Main(string[] args)
        {
            for (int i = 200; i <= 300; i++)
            {
                if (i % 7 == 0)
                    Console.WriteLine(i);
            }
        }
    }
}
