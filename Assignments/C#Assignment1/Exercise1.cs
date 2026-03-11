namespace C_Assignment1
{
    internal class Exercise1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double quotient = num1 / num2;

            Console.WriteLine("Quotient = " + quotient);
            Console.ReadLine();
        }
    }
}
