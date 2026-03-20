using System;
using System.Collections.Generic;
using System.Text;

namespace C_FileHandlingAssignment8
{
    internal class Exercise2
    {
        static void Main()
        {
            Console.WriteLine("1. Create Report");
            Console.WriteLine("2. Read Report");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                CreateReport();
            }
            else if (choice == 2)
            {
                ReadReport();
            }
        }

        static void CreateReport()
        {
            try
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Roll Number: ");
                string roll = Console.ReadLine();

                Console.Write("Marks (3 subjects): ");
                int m1 = Convert.ToInt32(Console.ReadLine());
                int m2 = Convert.ToInt32(Console.ReadLine());
                int m3 = Convert.ToInt32(Console.ReadLine());

                if (m1 < 0 || m2 < 0 || m3 < 0)
                {
                    Console.WriteLine("Invalid marks!");
                    return;
                }

                int total = m1 + m2 + m3;
                double avg = total / 3.0;

                string grade = avg >= 75 ? "A" :
                               avg >= 50 ? "B" :
                               avg >= 35 ? "C" : "Fail";

                string content = $"Student Name: {name}\nRoll Number: {roll}\nMarks: {m1},{m2},{m3}\nTotal: {total}\nAverage: {avg}\nGrade: {grade}";

                File.WriteAllText($"{roll}.txt", content);

                Console.WriteLine("Report saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void ReadReport()
        {
            try
            {
                Console.Write("Enter Roll Number: ");
                string roll = Console.ReadLine();

                string path = $"{roll}.txt";

                if (File.Exists(path))
                {
                    string data = File.ReadAllText(path);
                    Console.WriteLine("\n" + data);
                }
                else
                {
                    Console.WriteLine("Report not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
