using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Core.Mock.Repository
{
    public class MockTicketRepos : ITicketRepository
    {
        // Mock lavora con oggetti in memoria quindi va creata la lista 
        // Lo scopo è quello di non utilizzare i database, soprattutto per effettuare test sul codice 
        #region MOCK DATA
        private List<Ticket> _tickets = new List<Ticket>
        {
            new Ticket {
                Id = 1,
                Title = "Mock Ticket 1",
                Description = "Desc 1",
                IssueDate = DateTime.Now,
                Category = "A",
                Priority = "High",
                State = "New"
            },

            new Ticket {
                Id = 1,
                Title = "Mock Ticket 2",
                Description = "Desc 2",
                IssueDate = DateTime.Now,
                Category = "B",
                Priority = "Low",
                State = "OnGoing"
            },
            new Ticket {
                Id = 1,
                Title = "Mock Ticket 3",
                Description = "Desc 3",
                IssueDate = DateTime.Now,
                Category = "C",
                Priority = "High",
                State = "New"
            }
        }; 
        #endregion

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
            return _tickets;
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
