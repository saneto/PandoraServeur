using ServeurPandora.ModelVersionPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.IservicePRo
{
    public interface IHistoriqueCompteServicePro
    {
        IEnumerable<HistoriqueComptePro> GetAll(User User);
        HistoriqueComptePro GetHistoriqueCompte(User User);
        IEnumerable<HistoriqueComptePro> GetByDate(User User, DateTime Date);
    }
}
