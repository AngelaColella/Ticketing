using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ticketing.Client.Model;
using Ticketing.Helpers;

namespace Ticketing.Client.Context
{
    public sealed class TicketContext : DbContext
    {
        DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connString = Config.GetConnectionString("TicketDb");
            // non serve un'istanza della classe Config perchè stiamo usando metodi statici. 

            optionBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            var tickedModel = modelBuider.Entity<Ticket>(); // per evitare di doverlo scrivere ogni volta

            tickedModel
                .HasKey(t => t.Id); // non è necessario per il discroso della convenzione, ma se lo si vuole esplicitare, si scrive così

            tickedModel
                .Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            tickedModel
                .Property(t => t.Description)
                .HasMaxLength(500);

            tickedModel
                .Property(t => t.Category)
                .IsRequired();

        }
    }
}
