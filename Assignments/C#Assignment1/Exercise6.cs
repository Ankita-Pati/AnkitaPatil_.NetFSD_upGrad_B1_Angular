using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise6
    {
        static void Main(String[] args)
        {
            Console.Write("Enter length of rectangle: ");
            double length = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter breadth of rectangle: ");
            double breadth = Convert.ToDouble(Console.ReadLine());

            double rectangleArea = length * breadth;
            Console.WriteLine("Area of Rectangle = " + rectangleArea);

            Console.Write("Enter side of square: ");
            double side = Convert.ToDouble(Console.ReadLine());

            double squareArea = side * side;
            Console.WriteLine("Area of Square = " + squareArea);

            Console.ReadLine();
        }
    }
}
