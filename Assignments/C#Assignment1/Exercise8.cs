using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise8
    {
        static void Main(String[] args)
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            if (text.Length >= 3)
            {
                char ch = Char.ToLower(text[2]);

                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                    Console.WriteLine("Third character is a Vowel");
                else
                    Console.WriteLine("Third character is a Consonant");
            }
            else
            {
                Console.WriteLine("String must have at least 3 characters.");
            }

            Console.ReadLine();
        }
    }
}
