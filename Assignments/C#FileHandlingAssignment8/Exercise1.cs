using System;
using System.IO;
using System.Collections.Generic;
namespace C_FileHandlingAssignment8
{
    internal class Exercise1
    {
        static string filePath = "employee_log.txt";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Login Entry");
                Console.WriteLine("2. Update Logout Time");
                Console.WriteLine("3. Display Logs");
                Console.WriteLine("4. Exit");

                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddLogin();
                        break;
                    case 2:
                        UpdateLogout();
                        break;
                    case 3:
                        DisplayLogs();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void AddLogin()
        {
            try
            {
                Console.Write("Employee ID: ");
                string id = Console.ReadLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                string loginTime = DateTime.Now.ToString();
                string record = $"{id}|{name}|{loginTime}|";

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(record);
                }

                Console.WriteLine("Login recorded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void UpdateLogout()
        {
            try
            {
                Console.Write("Enter Employee ID: ");
                string id = Console.ReadLine();

                List<string> lines = new List<string>();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split('|');

                        if (parts[0] == id && parts[3] == "")
                        {
                            parts[3] = DateTime.Now.ToString();
                            line = string.Join("|", parts);
                        }

                        lines.Add(line);
                    }
                }

                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Logout updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void DisplayLogs()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
