using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Client.Model
{
    public class Note
    {
        public Note()
        {
            Ticket = new Ticket();
        }
        public int Id { get; set; }
        public string Comments { get; set; }

        // Aggiungo una Foreign Key
        public int TicketId { get; set; }

        // Navigation property 
        public virtual Ticket Ticket { get; set; }
    }
}
