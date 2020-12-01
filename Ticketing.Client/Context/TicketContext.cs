using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ticketing.Client.Model;
using Ticketing.Client.Model.Configuration;
using Ticketing.Helpers;

namespace Ticketing.Client.Context
{
    public sealed class TicketContext : DbContext
    {
        DbSet<Ticket> Tickets { get; set; }
        DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connString = Config.GetConnectionString("TicketDb");
            // non serve un'istanza della classe Config perchè stiamo usando metodi statici. 

            optionBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.ApplyConfiguration<Ticket>(new TicketConfiguration());
            modelBuider.ApplyConfiguration<Note>(new NoteConfiguration());
        }
    }
}
