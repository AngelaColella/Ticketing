using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Client.Model;

namespace Ticketing.Client.Context
{
    public class TicketContext : DbContext
    {
        DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("connString");
        }
    }
}
