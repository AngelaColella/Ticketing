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
                    case "n": // NOTE
                        var ticketId = GetData("Ticket ID");
                        int.TryParse(ticketId, out int tId);
                        var comments = GetData("Comment");
                        Note newNote = new Note
                        {
                            TicketId = tId,
                            Comments = comments
                        };
                        var noteResult = dataService.AddNote(newNote);
                        Console.WriteLine("Operation" + (noteResult ? "Completed" : "Failed"));
                        break;
                    case "l": // LIST
                        Console.WriteLine("-- TICKET LIST --");
                        foreach (var t in dataService.List())
                        {
                            Console.WriteLine($"{t.Id} - {t.Title}");
                            
                            foreach (var n in t.Notes)
                            {
                                Console.WriteLine($"{n.Comments}");
                            }
                            // il comportamento di default di Entity Framework è non popolare le navigation property, a meno che non sia esplicitato. Ciò è al fine di limitare il traffico di dati
                            // quindi con questo foreach non vengono letti i commenti
                        }
                        break;
                    case "x":
                        //var ticketId2 = GetData("");
                        //var ticket2 = dataService.GetTicketByIDviaSTP();
                        //int.TryParse(ticketId2, out int tId2);
                        break;
                    case "e": // EDIT
                        var ticketId3 = GetData("Ticket ID");
                        int.TryParse(ticketId3, out int tId3);
                        var ticket3 = dataService.GetTicketByID(tId3);

                        ticket3.Title = GetData("Title", ticket3.Title);
                        ticket3.Description = GetData("Description", ticket3.Description);
                        ticket3.Category = GetData("Category", ticket3.Category);
                        ticket3.Priority = GetData("Priority", ticket3.Priority);
                        ticket3.Requestor = GetData("Requestor", ticket3.Requestor);
                        ticket3.State = GetData("Stato", ticket3.State);

                        var editResult = dataService.Edit(ticket3);
                        Console.WriteLine("Operation" + (editResult ? "Completed" : "Failed"));
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

        private static string GetData(string message, string initialValue)
        {
            Console.Write(message + $"({initialValue}): "); // Write fa scrivere direttamente dopo il : invece che scriverlo a capo
            var value = Console.ReadLine();
            return string.IsNullOrEmpty(value) ? initialValue : value;
        }
    }
}
