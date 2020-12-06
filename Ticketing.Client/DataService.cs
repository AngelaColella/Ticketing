using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing.Client.Context;
using Ticketing.Client.Model;

namespace Ticketing.Client
{
    public class DataService
    {
        public void ListLazy()
        {
            using var ctx = new TicketContext();

            foreach (var t in ctx.Tickets) // Tickets è il DbSet
            {
                Console.WriteLine($"[{t.Id}] {t.Title}");
                foreach (var n in t.Notes)
                    Console.WriteLine($"\t{n.Comments}");
            }
           
        }

        public List<Ticket> ListEager()
        {
            using var ctx = new TicketContext();

            return ctx.Tickets
                .Include(t => t.Notes) // Popola la navigation property Notes di Ticket
                .ToList();
        }

        #region LIST
        // Con questo metodo, le note vengono vuote perchè non vengono popolate le navigation properties
        //public List<Ticket> List() 
        //{
        //    using var ctx = new TicketContext();

        //    return ctx.Tickets
        //        .ToList();           
        //}
        #endregion

        public bool Add(Ticket ticket)
        {
            try
            {
                using var ctx = new TicketContext();
                // per ogni riga che legge dal database, viene creata un'istanza di TicketContext

                if (ticket != null)
                {
                    ctx.Tickets.Add(ticket); // aggiunge il ticket ad DbSet
                    ctx.SaveChanges();
                }

                else
                    Console.WriteLine("Ticket can't be null");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }

        public bool AddNote(Note newNote)
        {
            try
            {
                using var ctx = new TicketContext();
             
                if (newNote != null) 
                {
                    var ticket = ctx.Tickets.Find(newNote.TicketId); // si recupera il ticket di riferimento tramite la foreign key
                    // Se cercassi di aggiungere una nota senza questo passaggio, il programma cercherebbe di creare un nuovo ticket da associare alla nuova nota
                    // è come se avesse fatto Ticket = new Ticket()
                    // Un'altra strada sarebbe stata valorizzare la navigation property
                            //newNote.Ticket = ticket;
                            //ctx.Notes.Add(newNote);
                            //ctx.SaveChanges();

                    if (ticket != null) 
                    {
                        ticket.Notes.Add(newNote);
                        ctx.SaveChanges();
                    }
 
                }

                else
                    Console.WriteLine("Note can't be null");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
          
        }

        public Ticket GetTicketByIDViaSTP(int id)
        {
            using var ctx = new TicketContext();
            SqlParameter idParam = new SqlParameter("@id", id);
            var result = ctx.Tickets.FromSqlRaw("exec stpGetTicketById @id", idParam).AsEnumerable();
            // se non avessi messo AsEnumerable, il programma non funzionerebbe quando lo si lancia perchè il tipo di result non sarebbe un IQuerable
           
            return result.FirstOrDefault();
        }

        public Ticket GetTicketByID(int id)
        {
            using var ctx = new TicketContext();
            
            if (id > 0)
                return ctx.Tickets.Find(id);

            return null;
        }

        public bool Edit(Ticket ticket)
        {
            // Qui bisogna usare una modalità disconnessa 
            using var ctx = new TicketContext();
            bool saved = false;

            do
            {
                try
                {
                    if (ticket == null)
                        return false;

                    // Se volessi fermare il programma per andare a simulare la concurrency modificando i dati da sql
                    // le due righe seguenti servono per far fermare l'applicazione e lasciare il tempo di modificare i dati
                    //Console.WriteLine("Wait");
                    //Console.ReadLine();

                    ctx.Entry<Ticket>(ticket).State = EntityState.Modified;
                    ctx.SaveChanges();

                    saved = true;
                }
                catch (DbUpdateConcurrencyException exc)
                {

                    Console.WriteLine("Error: " + exc.Message);
                    saved = false;
                } 
            } while (!saved);

            return true;
        }
    }
}