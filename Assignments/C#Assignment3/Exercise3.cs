using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment3
{
    class Hospital
    {
        public static string HospitalName;
        public static string HospitalAddress;

        public string PatientName;
    }
    internal class Exercise3
    {
        static void Main()
        {
            Hospital.HospitalName = "City Hospital";
            Hospital.HospitalAddress = "Bangalore";

            Hospital p1 = new Hospital();
            Hospital p2 = new Hospital();
            Hospital p3 = new Hospital();

            p1.PatientName = "Ravi";
            p2.PatientName = "Anita";
            p3.PatientName = "Rahul";

            Console.WriteLine(Hospital.HospitalName + " - " + Hospital.HospitalAddress);
            Console.WriteLine("Patient: " + p1.PatientName);
            Console.WriteLine("Patient: " + p2.PatientName);
            Console.WriteLine("Patient: " + p3.PatientName);
        }
    }
}
