using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Core.Model
{
    public class Note
    {
        // va tolto il costruttore con l'inizializzazione della lista vuota a causa dell'aggiornamento di EF
        
        //public Note()
        //{
        //    Ticket = new Ticket();
        //}
        public int Id { get; set; }
        public string Comments { get; set; }

        // Aggiungo una Foreign Key
        public int TicketId { get; set; }

        // CONCURRENCY MANAGEMENT
        public Byte[] RowVersion { get; set; }

        // Navigation property 
        public virtual Ticket Ticket { get; set; }
    }
}
