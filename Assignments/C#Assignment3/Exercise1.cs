namespace C_Assignment3
{
    class Patient
    {
        public int PatientId;
        public string PatientName;
        public byte Age;
        public string Disease;
    }
    internal class Exercise1
    {
        static void Main(string[] args)
        {
            Patient p = new Patient();
            p.PatientId = 101;
            p.PatientName = "Ravi Kumar";
            p.Age = 45;
            p.Disease = "Diabetes";
            Console.WriteLine("Patient Id: " + p.PatientId);
            Console.WriteLine("Patient Name: " + p.PatientName);
            Console.WriteLine("Age: " + p.Age);
            Console.WriteLine("Disease: " + p.Disease);
        }
    }
}
