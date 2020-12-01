using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Client.Model.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder
                 .HasKey(n => n.Id);

            builder
                .Property(n => n.Comments)
                .HasMaxLength(1000)
                .IsRequired();

            // se avessi voluto impostare qui la relazione tra Note e Ticket
            // in realtà è meglio impostarla in TicketConfiguration

            //builder
            //    .HasOne(n => n.Ticket)
            //    .WithMany(t => t.Notes);

        }
    }
}
