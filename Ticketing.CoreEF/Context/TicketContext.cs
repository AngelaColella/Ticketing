﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using Ticketing.Client.Model;
//using Ticketing.Client.Model.Configuration;
using Ticketing.Core.Model;
using Ticketing.CoreEF.Model.Configuration;
using Ticketing.Helpers;

namespace Ticketing.CoreEF.Context
{
    public sealed class TicketContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connString = Config.GetConnectionString("TicketDb");

            optionBuilder.UseLazyLoadingProxies(); // Lazy Loading
            optionBuilder.UseSqlServer(connString);       
        }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.ApplyConfiguration<Ticket>(new TicketConfiguration());
            modelBuider.ApplyConfiguration<Note>(new NoteConfiguration());
        }
    }
}