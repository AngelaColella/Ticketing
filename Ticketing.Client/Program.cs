using System;
using Ticketing.Client.Model;

namespace Ticketing.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService();

            Console.WriteLine(" TICKET MANAGEMENT ");
            bool quit = false;

            do
            {
                string command = Console.ReadLine();

                Console.WriteLine("Insert a command: \n");
                switch (command)
                {
                    case "q":
                        quit = true;
                        break;
                    case "a": // ADD
                        Ticket ticket = new Ticket();
                        ticket.Title = GetData("Title");
                        ticket.Description = GetData("Description");
                        ticket.Category = GetData("Category");
                        ticket.Priority = GetData("Priority");
                        ticket.Requestor = GetData("Requestor");
                        ticket.State = "New";
                        ticket.IssueDate = DateTime.Now;

                        var result = dataService.Add(ticket);
                        Console.WriteLine("Operation" + (result ? "Completed" : "Failed"));
                        // è un ternario: corrisponde ad un if else. 
                        // If result true => Completed , else => Failed
                        break;
                    case "l": // LIST
                        Console.WriteLine("-- TICKET LIST --");
                        foreach (var t in dataService.List())
                        {
                            Console.WriteLine($"{t.Id} - {t.Title}");
                        }
                        break;
                    case "e": // EDIT
                        break;
                    case "d": // DELETE
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                } 

            } while (!quit);

            // nel do while il test è alla fine, quindi il codice che c'è dentro viene letto almeno una volta

            Console.WriteLine("\n Bye bye");
        }

        private static string GetData(string message)
        {
            Console.Write(message + ": ");
            var value = Console.ReadLine();
            return value;      
        }
    }
}
