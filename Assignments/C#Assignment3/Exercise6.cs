using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment3
{
    class Billing
    {
        public string PatientName;
        public double ConsultationFee;
        public double TestCharges;

        public void CalculateTotalBill()
        {
            double total = ConsultationFee + TestCharges;

            Console.WriteLine("Patient Name: " + PatientName);
            Console.WriteLine("Total Bill: " + total);
        }
    }
    internal class Exercise6
    {
        static void Main()
        {
            Billing b = new Billing();

            b.PatientName = "Ramesh";
            b.ConsultationFee = 500;
            b.TestCharges = 1000;

            b.CalculateTotalBill();
        }
    }
}
