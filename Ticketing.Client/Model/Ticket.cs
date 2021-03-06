﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ticketing.Client.Model
{
    public class Ticket
    {
        //Non c'è bisogno di creare questo costruttore, anzi darebbe problemi a causa di un aggiornamento di EF 

        //public Ticket()
        //{
        //    Notes = new List<Note>();
        //}

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
        public string Requestor { get; set; }

        // CONCURRENCY MANAGEMENT
        public Byte[] RowVersion { get; set; }

        // Navigation property perchè abbiamo aggiunto la classe Notes
        // monodirezionale se la metto solo in Ticket, bidirezionale se ne metto una anche in Note
        // N.B. Deve essere sempre virtual 
        // Lista di note perchè stiamo implementando una relazione uno a molti: un Ticket può avere molte note
        public virtual List<Note> Notes { get; set; }
    }
}
