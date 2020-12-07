using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;

namespace Ticketing.Core.Repository
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Ticket GetTicketByTitle(string title);
        // Il motivo per cui si è creata un'interfaccia per ciasuna entità è che potrebbe essere necessario avere un metodo 
        // solo per Ticket e non per Notes, che quindi non potrà essere inserito in una interfaccia comune
    }
}
