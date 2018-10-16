using ServeurPandora.IservicePRo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.ModelVersionPro;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Mvc;
using ServeurPandora.Models;
using Microsoft.Data.Entity;
namespace ServeurPandora.ServicePro
{
    public class HistoriqueAccesServicePro : IHistoriqueAccesServicePro
    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<Controller> Logger { get; set; }
        public HistoriqueAccesServicePro()
        {
            dataModel = new DataModel();
        }
        public IEnumerable<HistoriqueAccesPro> Get(User User)
        {
            User pro = dataModel.Users.Where(p => p == User).Include(j => j.Profile).ThenInclude((ProfilePro A) => A.Acces).ThenInclude((AccesPro g)=>g.HisotriqueAccesPro).First();
            List<ProfilePro> m = pro.Profile;
            List<HistoriqueAccesPro> HA = new List<HistoriqueAccesPro>();
            foreach (ProfilePro v in m)
            {
                foreach (AccesPro w in v.Acces)
                {
                    HA.Add(w.HisotriqueAccesPro.Last());
                }
            }

            return HA.AsEnumerable();
        }

        public IEnumerable<HistoriqueAccesPro> GetByDate(AccesPro Acces, DateTime Date)
        {
            AccesPro AP = dataModel
                        .AccesPro
                        .Include(m => m.HisotriqueAccesPro)
                        .Single(k => k.Profile == Acces.Profile
                        && k.login == Acces.login
                        && k.HisotriqueAccesPro
                        .Where(x =>
                        x.Connexion.Day == Date.Day  &&
                        x.Connexion.Month == Date.Month)!=null) ;
                return AP.HisotriqueAccesPro;
        }

        public IEnumerable<HistoriqueAccesPro> GetByDate(User User, DateTime date)
        {
            List<ProfilePro> Us = dataModel.Users
                                  .Where(p => p == User)
                                  .Include(j => j.Profile)
                                  .ThenInclude((ProfilePro A) => A.Acces)
                                  .ThenInclude((AccesPro Ap)=> Ap.HisotriqueAccesPro)
                                  .Where(t => t.Profile.
                                       Where(l =>
                                       l.Acces.Where(v =>v.HisotriqueAccesPro
                                               .Where(x =>x.Connexion.Day == date.Day
                                                   &&
                                                   x.Connexion.Month == date.Month
                                                   &&
                                                   x.Connexion.Year == date.Year)
                                               != null)
                                       != null)
                                   != null).First().Profile;
            List<HistoriqueAccesPro> HA = new List<HistoriqueAccesPro>();
            foreach (ProfilePro v in Us)
            {
                foreach (AccesPro w in v.Acces)
                {
                    HA.AddRange(w.HisotriqueAccesPro);
                }

            }

            return HA.AsEnumerable();
        }

        public HistoriqueAccesPro GetLast(AccesPro Acces)
        {
            HistoriqueAccesPro HP = dataModel.AccesPro.Single(A => A == Acces).HisotriqueAccesPro.Last();
            return HP;
        }
        public IEnumerable<HistoriqueAccesPro> GetByProfile(ProfilePro Pro)
        {
            List<AccesPro> AP= dataModel.ProfilesPro
                .Include(A => A.Acces)
                .ThenInclude((AccesPro h) => h.HisotriqueAccesPro)
                .First(m => m == Pro).Acces;
            List<HistoriqueAccesPro> HAP = new List<HistoriqueAccesPro>();
           foreach (AccesPro w in AP)
                {
                    HAP.AddRange(w.HisotriqueAccesPro);
                }
           return HAP.AsEnumerable();

        }
    }
}
