using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment3
{
    class Doctor
    {
        public int DoctorId;
        public string DoctorName;
        public string Specialization;
        public double ConsultationFee;
    }
    internal class Exercise2
    {
        static void Main()
        {
            Doctor d1 = new Doctor();
            Doctor d2 = new Doctor();

            d1.DoctorId = 1;
            d1.DoctorName = "Dr. Sharma";
            d1.Specialization = "Cardiology";
            d1.ConsultationFee = 500;

            d2.DoctorId = 2;
            d2.DoctorName = "Dr. Mehta";
            d2.Specialization = "Dermatology";
            d2.ConsultationFee = 400;

            Console.WriteLine("Doctor 1: " + d1.DoctorName + " - " + d1.Specialization);
            Console.WriteLine("Doctor 2: " + d2.DoctorName + " - " + d2.Specialization);
        }
    }
}

