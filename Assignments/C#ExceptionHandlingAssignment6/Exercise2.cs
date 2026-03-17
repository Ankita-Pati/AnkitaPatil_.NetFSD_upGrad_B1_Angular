using C_ExpectionHandlingAssignment6;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_ExpectionHandlingAssignment6
{
    class TicketLimitExceededException : Exception
    {
        public TicketLimitExceededException(string message) : base(message)
        {
        }
    }
    internal class Exercise2
    {
        static void Main()
        {
            int availableTickets = 15;

            try
            {
                Console.WriteLine("Do you want to book tickets? (yes/no)");
                string choice = Console.ReadLine().ToLower();

                if (choice == "yes")
                {
                    Console.WriteLine("Enter number of tickets:");
                    int tickets = Convert.ToInt32(Console.ReadLine());

                    if (tickets > availableTickets)
                    {
                        throw new TicketLimitExceededException("Tickets exceed available limit!");
                    }

                    availableTickets -= tickets;

                    Console.WriteLine("Tickets booked successfully!");
                    Console.WriteLine("Remaining tickets: " + availableTickets);
                }
                else
                {
                    Console.WriteLine("Booking cancelled.");
                }
            }
            catch (TicketLimitExceededException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input! " + ex.Message);
            }
        }
    }
}
