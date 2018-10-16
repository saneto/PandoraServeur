using ServeurPandora.IservicePRo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.ModelVersionPro;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ServeurPandora.Models;
using Microsoft.Data.Entity;
namespace ServeurPandora.ServicePro
{
    public class HistoriqueCompteServicePro : IHistoriqueCompteServicePro
    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<Controller> Logger { get; set; }
        public HistoriqueCompteServicePro()
        {
            dataModel = new DataModel();
        }
        public IEnumerable<HistoriqueComptePro> GetAll(User User)
        {
            User t = dataModel.Users
                .Include(c => c.HistoriqueCompte)
                .Single(p => p.Email == User.Email && p.IdUser == User.IdUser);
            List<HistoriqueComptePro> HC = t.HistoriqueCompte;
            return HC.AsEnumerable();
        }


        public IEnumerable<HistoriqueComptePro> GetByDate(User User, DateTime Date)
        {
            IEnumerable<HistoriqueComptePro> HC = dataModel.Users
                                            .Where(p => p.Email == User.Email && p.IdUser == User.IdUser)
                                            .Include(c => c.HistoriqueCompte)
                                            .First()
                                            .HistoriqueCompte
                                            .Where(m => m.Connexion.Day == Date.Day && m.Connexion.Month == Date.Month);
            //= t.HistoriqueCompte;
            return HC.AsEnumerable();
        }



        public HistoriqueComptePro GetHistoriqueCompte(User User)
        {
            User t = dataModel.Users.
                    Include(c => c.HistoriqueCompte)
                    .Single(p => p.Email == User.Email && p.IdUser == User.IdUser);
            IList<HistoriqueComptePro> HC = t.HistoriqueCompte;
            return HC.Last();
        }


    }
}
