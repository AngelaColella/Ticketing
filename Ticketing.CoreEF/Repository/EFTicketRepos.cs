using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ticketing.Core;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;
using Ticketing.CoreEF.Context;

namespace Ticketing.CoreEF.Repository
{
    public class EFTicketRepos : ITicketRepository
    {
        private TicketContext _ctx = new TicketContext();

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
            if (filter != null)     // dove filter è una Func
                return _ctx.Tickets
                    .Where(filter);

            return _ctx.Tickets;
        }

        public Ticket GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
