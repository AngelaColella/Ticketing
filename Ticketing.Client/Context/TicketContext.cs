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
        public DbSet<Ticket> Tickets { get; set; }
        // N.B. anche se la classe è public, ciò che c'è dentro è private se non si specifica altirmenti 
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connString = Config.GetConnectionString("TicketDb");
            // non serve un'istanza della classe Config perchè stiamo usando metodi statici. 
            // OPPURE se nel file json ci fosse più di una section
            // string connString = Config.GetSection("ConnectionStrings")["TicketDb"];

            //optionBuilder.UseLazyLoadingProxies(); // Lazy Loading
            //optionBuilder.UseSqlServer(connString);       
        }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.ApplyConfiguration<Ticket>(new TicketConfiguration());
            modelBuider.ApplyConfiguration<Note>(new NoteConfiguration());
        }
    }
}
