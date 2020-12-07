using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Core
{
    public class DataService
    {
        #region DEPENDENCY INJECTION
        private readonly ITicketRepository ticketRepo;
        private readonly INoteRepository noteRepo;

        public DataService(ITicketRepository ticketRepo, INoteRepository noteRepo) 
            //i parametri di 
        {
            this.ticketRepo = ticketRepo;
            this.noteRepo = noteRepo;
        } 
        #endregion

        #region Codice precedente alla depencency injection (stessa cose per gli altri commenti di questa classe)
        // A seconda di quale progetto sto usando, decommento la riga di codice che mi serve. è l'unica cosa che devo cambiare 
        //private ITicketRepository GetTicketRepository()
        //{
        //    return null;
        //    //return new Ticketing.Core.ADONET.Repository.ADONETTicketRepository();
        //    //return new Ticketing.Core.EF.Repository.EFTicketRepository();
        //    //return new Ticketing.Core.Mock.Repository.MockTicketRepository();
        //}

        //private INoteRepository GetNoteRepository()
        //{
        //    return null;
        //    //return new Ticketing.Core.EF.Repository.EFNoteRepository();
        //    //return new Ticketing.Core.Mock.Repository.MockNoteRepository();
        //}

        #endregion

        public List<Ticket> List()
        {
            //ITicketRepository repo = GetTicketRepository();
            return ticketRepo.Get().ToList();
        }

        public bool Add(Ticket ticket)
        {
            try
            {
                //ITicketRepository repo = GetTicketRepository();

                if (ticket != null)
                {
                    var result = ticketRepo.Add(ticket);
                    return result;
                }
                else
                {
                    Console.WriteLine("Ticket can't be null.");
                    return true;
                }
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
                //INoteRepository repo = GetNoteRepository();

                if (newNote != null)
                {
                    noteRepo.Add(newNote);
                }
                else
                    Console.WriteLine("Note can't be null.");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Ticket GetTicketById(int id)
        {
            //ITicketRepository repo = GetTicketRepository();

            if (id > 0)
                return ticketRepo.GetByID(id);

            return null;
        }

        public bool Update(Ticket ticket)
        {
            try
            {
                //ITicketRepository repo = GetTicketRepository();

                if (ticket == null)
                    return false;

                Console.WriteLine("Concurrency simulation. Press a key to restar");
                Console.ReadKey();

                ticketRepo.Update(ticket);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
