using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core;
using Ticketing.Core.Repository;
using Ticketing.CoreEF.Repository;
using Ticketing.Helpers;

namespace Ticketing.Client
{
    public class DIConfig
    {
        private static readonly string strConnection = Config.GetConnectionString("TicketingDb");

        public static ServiceProvider ConfigDI()
        {
            return new ServiceCollection()
                .AddTransient<DataService>()
                //.AddTransient<ITicketRepository, MockTicketRepo>()
                //.AddTransient<INoteRepository, MockNoteRepo>()
                .AddTransient<ITicketRepository, EFTicketRepos>()
                .AddTransient<INoteRepository, EFNoteRepos>()
                //.AddDbContext<TicketContext>()
                .BuildServiceProvider();
        }
    }
}
