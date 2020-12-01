using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Client.Model
{
    public class Ticket
    {
        public int Id { get; set; } // per rispettare la convenzione della chiave primaria avrei potuto scrivere anche TicketId, ID, TicketID

        public DateTime IssueDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
        public string Priority { get; set; }

        public string State { get; set; }
    }
}
