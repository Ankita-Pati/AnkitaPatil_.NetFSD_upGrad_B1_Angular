using System;
using System.Collections.Generic;
using System.Text;

namespace C_InheritanceAssignment4
{
    class Furniture
    {
        public int OrderId;
        public string OrderDate;
        public string FurnitureType;
        public int Qty;
        public double TotalAmt;
        public string PaymentMode;

        public virtual void GetData()
        {
            Console.Write("Order Id: ");
            OrderId = int.Parse(Console.ReadLine());

            Console.Write("Order Date: ");
            OrderDate = Console.ReadLine();

            Console.Write("Quantity: ");
            Qty = int.Parse(Console.ReadLine());

            Console.Write("Payment Mode (Credit/Debit): ");
            PaymentMode = Console.ReadLine();
        }

        public virtual void ShowData()
        {
            Console.WriteLine("Order Id: " + OrderId);
            Console.WriteLine("Order Date: " + OrderDate);
            Console.WriteLine("Quantity: " + Qty);
            Console.WriteLine("Payment Mode: " + PaymentMode);
        }
    }

    class Chair : Furniture
    {
        public string ChairType;
        public string Purpose;
        public string MaterialType;
        public double Rate;

        public override void GetData()
        {
            base.GetData();

            Console.Write("Chair Type (Wood/Steel/Plastic): ");
            ChairType = Console.ReadLine();

            Console.Write("Purpose (Home/Office): ");
            Purpose = Console.ReadLine();

            Console.Write("Material Type: ");
            MaterialType = Console.ReadLine();

            Console.Write("Rate: ");
            Rate = double.Parse(Console.ReadLine());

            TotalAmt = Qty * Rate;
        }

        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine("Chair Type: " + ChairType);
            Console.WriteLine("Purpose: " + Purpose);
            Console.WriteLine("Material: " + MaterialType);
            Console.WriteLine("Rate: " + Rate);
            Console.WriteLine("Total Amount: " + TotalAmt);
        }
    }

    class Cot : Furniture
    {
        public string CotType;
        public string Capacity;
        public double Rate;

        public override void GetData()
        {
            base.GetData();

            Console.Write("Cot Type (Wood/Steel): ");
            CotType = Console.ReadLine();

            Console.Write("Capacity (Single/Double): ");
            Capacity = Console.ReadLine();

            Console.Write("Rate: ");
            Rate = double.Parse(Console.ReadLine());

            TotalAmt = Qty * Rate;
        }

        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine("Cot Type: " + CotType);
            Console.WriteLine("Capacity: " + Capacity);
            Console.WriteLine("Rate: " + Rate);
            Console.WriteLine("Total Amount: " + TotalAmt);
        }
    }

    internal class Exercise6
    {
        static void Main()
        {
            Chair c = new Chair();
            c.GetData();
            c.ShowData();

            Cot cot = new Cot();
            cot.GetData();
            cot.ShowData();
        }
    }
}
