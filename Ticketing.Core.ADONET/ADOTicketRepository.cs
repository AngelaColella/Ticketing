using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Core.ADONET
{
    public class ADOTicketRepository : ITicketRepository 
    {
        public bool Add(Ticket item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Get(Func<Ticket, bool> filter = null)
        {
            return new List<Ticket>
            {
                new Ticket
                {
                    Id = 99,
                    Title = "ADO.NET"
                }
            };
        }

        public Ticket GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
