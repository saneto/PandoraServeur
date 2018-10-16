using ServeurPandora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.IService
{
    public interface IHistoriqueCompte
    {
        IEnumerable<HistoriqueCompte> GetAll(profile Profile);
        HistoriqueCompte GetHistoriqueCompte(profile Profile);
        IEnumerable<HistoriqueCompte> GetByDate(profile Profile, DateTime Date);
    }
}
