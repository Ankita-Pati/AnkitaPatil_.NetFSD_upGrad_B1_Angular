using System;
using System.Collections.Generic;
using System.Text;

namespace C_InheritanceAssignment4
{
    class Account
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }

        public void CalculateInterest()
        {
            Console.WriteLine("Base account interest calculation");
        }
    }

    class SavingsAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Savings account interest = 5%");
        }
    }

    class CurrentAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Current account interest = 2%");
        }
    }

    internal class Exercise2
    {
        static void Main()
        {
            Account acc = new SavingsAccount();
            acc.CalculateInterest();
        }
    }
}
