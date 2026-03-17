using System;
using System.Collections.Generic;
using System.Text;

namespace C_InterfacesAssignment5
{
    interface IYearlySales
    {
        int YearlySales();
    }
    abstract class Sales
    {
        // Non-abstract method
        public int DailySales()
        {
            return 400;
        }

        // Abstract method
        public abstract int MonthlySales();
    }

    class SalesCalculator : Sales, IYearlySales
    {
        public override int MonthlySales()
        {
            return DailySales() * 30;
        }

        public int YearlySales()
        {
            return MonthlySales() * 12;
        }
    }
    internal class Exercise2
    {
        static void Main(string[] args)
        {
            SalesCalculator sc = new SalesCalculator();

            Console.WriteLine("Daily sales: Rs." + sc.DailySales());
            Console.WriteLine("Monthly sales: Rs." + sc.MonthlySales());
            Console.WriteLine("Annual sales: Rs." + sc.YearlySales());
        }
    }
}
