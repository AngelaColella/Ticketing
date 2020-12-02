using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Core.Repository
{
    // Interfaccia dietro cui si nasconde l'accesso al dato 
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> Get(Func<T, bool> filter = null);
        // repository.Get(t => t.Name == "Roberto")
        // il bool è il risultato della comparazione tra t.Name == "Robero"
        // se il filter è null, cioè se scrivo Get e basta, mi restituisce tutta la lista
        
        T GetByID(int id);
        bool Add(T item);
        bool Update(T item);
        bool DeleteById(int id);

    }
}
