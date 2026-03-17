namespace C_InterfacesAssignment5
{
    interface GovtRules
    {
        double EmployeePF(double basicSalary);
        string LeaveDetails();
        double GratuityAmount(float serviceCompleted, double basicSalary);
    }

    class TCS : GovtRules
    {
        // Data Members
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Desg { get; set; }
        public double BasicSalary { get; set; }

        // Constructor
        public TCS(int empId, string name, string dept, string desg, double basicSalary)
        {
            EmpId = empId;
            Name = name;
            Dept = dept;
            Desg = desg;
            BasicSalary = basicSalary;
        }

        // PF Calculation
        public double EmployeePF(double basicSalary)
        {
            double empPF = 0.12 * basicSalary;
            double employerPF = 0.0833 * basicSalary;
            double pension = 0.0367 * basicSalary;

            Console.WriteLine($"Employee PF: {empPF}");
            Console.WriteLine($"Employer PF: {employerPF}");
            Console.WriteLine($"Pension Fund: {pension}");

            return empPF + employerPF + pension;
        }

        // Leave Details
        public string LeaveDetails()
        {
            return "1 Casual Leave/month\n12 Sick Leave/year\n10 Privilege Leave/year";
        }

        // Gratuity
        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20)
                return 3 * basicSalary;
            else if (serviceCompleted > 10)
                return 2 * basicSalary;
            else if (serviceCompleted > 5)
                return basicSalary;
            else
                return 0;
        }

        public void Display()
        {
            Console.WriteLine($"TCS Employee: {EmpId}, {Name}, {Dept}, {Desg}, Salary: {BasicSalary}");
        }
    }

    class Accenture : GovtRules
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Desg { get; set; }
        public double BasicSalary { get; set; }

        public Accenture(int empId, string name, string dept, string desg, double basicSalary)
        {
            EmpId = empId;
            Name = name;
            Dept = dept;
            Desg = desg;
            BasicSalary = basicSalary;
        }

        public double EmployeePF(double basicSalary)
        {
            double empPF = 0.12 * basicSalary;
            double employerPF = 0.12 * basicSalary;

            Console.WriteLine($"Employee PF: {empPF}");
            Console.WriteLine($"Employer PF: {employerPF}");

            return empPF + employerPF;
        }

        public string LeaveDetails()
        {
            return "2 Casual Leave/month\n5 Sick Leave/year\n5 Privilege Leave/year";
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0; // Not applicable
        }

        public void Display()
        {
            Console.WriteLine($"Accenture Employee: {EmpId}, {Name}, {Dept}, {Desg}, Salary: {BasicSalary}");
        }
    }

    internal class Exercise1
    {
            static void Main(string[] args)
            {
                // TCS Employee
                TCS t = new TCS(1, "Rahul", "IT", "Developer", 50000);
                t.Display();
                Console.WriteLine("PF Total: " + t.EmployeePF(t.BasicSalary));
                Console.WriteLine("Leave Details:\n" + t.LeaveDetails());
                Console.WriteLine("Gratuity: " + t.GratuityAmount(12, t.BasicSalary));

                Console.WriteLine("--------------------------------");

                // Accenture Employee
                Accenture a = new Accenture(2, "Anita", "HR", "Manager", 60000);
                a.Display();
                Console.WriteLine("PF Total: " + a.EmployeePF(a.BasicSalary));
                Console.WriteLine("Leave Details:\n" + a.LeaveDetails());
                Console.WriteLine("Gratuity: " + a.GratuityAmount(8, a.BasicSalary));
            }
        }
    }
