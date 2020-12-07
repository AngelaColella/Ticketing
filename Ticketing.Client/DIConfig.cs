using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Helpers;

namespace Ticketing.Client
{
    public class DIConfig
    {
        private static readonly string strConnection =
           Config.GetConnectionString("TicketingDb");

        public static ServiceProvider ConfigDI()
        {
            return new ServiceCollection()
                .AddTransient<DataService>()
                //.AddTransient<ITicketRepository, MockTicketRepo>()
                //.AddTransient<INoteRepository, MockNoteRepo>()
                .AddTransient<ITicketRepository, EFTicketRepository>()
                .AddTransient<INoteRepository, EFNoteRepository>()
                //.AddDbContext<TicketContext>()
                .BuildServiceProvider();
        }
    }
}
