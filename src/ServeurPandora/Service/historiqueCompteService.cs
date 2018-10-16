using ServeurPandora.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Mvc;
using ServeurPandora.Controllers;
using Microsoft.Data.Entity;
namespace ServeurPandora.Service
{
    public class HistoriqueCompteService : IHistoriqueCompte
    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<Controller> Logger { get; set; }
        public HistoriqueCompteService()
        {
            dataModel = new DataModel();
        }
        public IEnumerable<Models.HistoriqueCompte> GetAll(profile Profile)
        {
            profile t = dataModel.Profiles.Include(c => c.HistoriqueCompte).Single(p => p.Email == Profile.Email && p.ID == Profile.ID);
            IList<HistoriqueCompte> HC = t.HistoriqueCompte;
            return HC.AsEnumerable();
        }

        public IEnumerable<Models.HistoriqueCompte> GetByDate(profile Profile, DateTime Date)
        {
            IEnumerable<HistoriqueCompte> HC = dataModel.Profiles.Where(p => p.Email == Profile.Email && p.ID == Profile.ID).Include(c => c.HistoriqueCompte).First().HistoriqueCompte.Where(m=> m.Connexion==Date);
             //= t.HistoriqueCompte;
            return HC.AsEnumerable();
        }

        public Models.HistoriqueCompte GetHistoriqueCompte(profile Profile)
        {
            profile t = dataModel.Profiles.Include(c => c.HistoriqueCompte).Single(p => p.Email == Profile.Email && p.ID == Profile.ID);
            IList<HistoriqueCompte> HC = t.HistoriqueCompte;
            return HC.Last();
        }
    }
}
