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
                Console.WriteLine("-------------------\n");
                Console.WriteLine("Insert a command:");
                string command = Console.ReadLine();
             
                switch (command)
                {
                    case "q":
                        quit = true;
                        break;

                    case "a": // ADD TICKET
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

                    case "n": // ADD NOTE
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

                    case "l": // LIST EAGER
                        foreach (var t in dataService.ListEager())
                        {
                            Console.WriteLine($"[{t.Id}] {t.Title} {t.Description}{t.Category}{t.Priority} {t.Requestor}");
                            foreach (var n in t.Notes)
                                Console.WriteLine($"\t{n.Comments}");
                        }

                        #region METODO LIST ()
                        //Console.WriteLine("-- TICKET LIST --");
                        //foreach (var t in dataService.List())
                        //{
                        //    Console.WriteLine($"{t.Id} - {t.Title}");

                        //    foreach (var n in t.Notes)
                        //    {
                        //        Console.WriteLine($"{n.Comments}");
                        //    }
                        //    // il comportamento di default di Entity Framework è non popolare le navigation property, a meno che non sia esplicitato. Ciò è al fine di limitare il traffico di dati
                        //    // quindi con questo foreach non vengono lette le note
                        //} 
                        #endregion
                        
                        break;
                    case "z":
                        dataService.ListLazy(); // La stampa non si può fare da program perchè il context deve essere aperto
                        break;

                    case "x":
                        var ticketId2 = GetData("Ticket ID");
                        int.TryParse(ticketId2, out int tId2);
                        var ticket2 = dataService.GetTicketByIDViaSTP(tId2);
                        Console.WriteLine(ticket2 != null ? ticket2.Description : "niente ...");
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

            Console.WriteLine("\n Bye bye!!");
        }

        private static string GetData(string message)
        {
            Console.Write(message + ": "); // Write fa scrivere direttamente dopo il : invece che scriverlo a capo
            var value = Console.ReadLine();
            return value;      
        }

        private static string GetData(string message, string initialValue) // nel caso in cui si voglia anche fare un confronto del dato inserito con il valore del dato corrente 
        {
            Console.Write(message + $"({initialValue}): "); 
            var value = Console.ReadLine();
            return string.IsNullOrEmpty(value) ? initialValue : value;
            // se la stringa value scritta da linea di comando è vuota o null, utilizza il valore che era già assegnato al campo (initialValue), altrimenti usa value. 
        }
    }
}
