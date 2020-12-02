using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Client.Model.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
      
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            //var builder = modelBuider.Entity<Ticket>(); // per evitare di doverlo scrivere ogni volta

            builder
                .HasKey(t => t.Id); // non è necessario per il discroso della convenzione, ma se lo si vuole esplicitare, si scrive così

            builder
                .Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(t => t.Description)
                    .HasMaxLength(500);

            builder
                .Property(t => t.Category)
                    .IsRequired();

            builder
                .Property(t => t.Requestor)
                    .HasMaxLength(50)
                    .IsRequired();

            builder
                .HasMany(t => t.Notes)
                .WithOne(n => n.Ticket) // ciascuna di queste note è legata ad un ticket
                .HasForeignKey(n => n.TicketId)
                .HasConstraintName("FK_Ticket_Note") // altrimenti mette un nome a caso 
                .OnDelete(DeleteBehavior.Cascade);
            // se cancello un ticket, viene cancellata la nota
           
            
            // CONCURRENCY MANAGEMENT
            builder
                .Property(n => n.RowVersion)
                .IsRowVersion();

        }
    }
}
