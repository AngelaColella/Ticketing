using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ticketing.Client.Model
{
    public class Ticket
    {
        //[Key]
        public int Id { get; set; } // per rispettare la convenzione della chiave primaria avrei potuto scrivere anche TicketId, ID, TicketID

        public DateTime IssueDate { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string Title { get; set; }
        //[MaxLength(500)]
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string State { get; set; }
    }
}
