using System;

namespace C_InheritanceAssignment4
{
    class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public Staff(int id, string name, double salary)
        {
            StaffId = id;
            Name = name;
            BaseSalary = salary;
        }

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    class Doctor : Staff
    {
        public double ConsultationFee { get; set; }

        public Doctor(int id, string name, double salary, double fee)
            : base(id, name, salary)
        {
            ConsultationFee = fee;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + ConsultationFee;
        }
    }

    class Nurse : Staff
    {
        public double NightShiftAllowance { get; set; }

        public Nurse(int id, string name, double salary, double allowance)
            : base(id, name, salary)
        {
            NightShiftAllowance = allowance;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + NightShiftAllowance;
        }
    }

    class LabTechnician : Staff
    {
        public double EquipmentAllowance { get; set; }

        public LabTechnician(int id, string name, double salary, double allowance)
            : base(id, name, salary)
        {
            EquipmentAllowance = allowance;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + EquipmentAllowance;
        }
    }

    internal class Exercise1
    {
        static void Main(string[] args)
        {
            Staff[] staffList =
            {
            new Doctor(1,"Dr. Ravi",50000,20000),
            new Nurse(2,"Anita",30000,5000),
            new LabTechnician(3,"Rahul",25000,3000)
        };

            foreach (Staff s in staffList)
            {
                Console.WriteLine(s.Name + " Salary: " + s.CalculateSalary());
            }
        }
    }
  
}
