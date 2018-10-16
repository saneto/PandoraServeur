using ServeurPandora.ModelVersionPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.IservicePRo
{
    public interface IHistoriqueAccesServicePro
    {
        IEnumerable<HistoriqueAccesPro> Get(User User);
        IEnumerable<HistoriqueAccesPro> GetByDate(User User, DateTime date);
        IEnumerable<HistoriqueAccesPro> GetByDate(AccesPro Acces, DateTime Date);
        HistoriqueAccesPro GetLast(AccesPro Acces);
        IEnumerable<HistoriqueAccesPro> GetByProfile(ProfilePro Pro);
    }
}
