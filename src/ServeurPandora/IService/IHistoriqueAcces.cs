using ServeurPandora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.IService
{
    public interface IHistoriqueAcces
    {
        List<HistoriqueAcces> Get(profile Profile);
        IEnumerable<HistoriqueAcces> GetByDate(profile Acces, DateTime date);
        IEnumerable<HistoriqueAcces> GetByDate(Acces Acces, DateTime Date);
        HistoriqueAcces GetLast(Acces Acces);
    }
}
