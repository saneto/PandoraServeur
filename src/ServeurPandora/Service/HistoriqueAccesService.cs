using ServeurPandora.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Threading;
using ServeurPandora.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using ServeurPandora.Controllers;

namespace ServeurPandora.Service
{
    public class HistoriqueAccesService : IHistoriqueAcces

    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<Controller> Logger { get; set; }
        List<Acces> A = new List<Acces>();
       // Acces L = new Acces();
        List<Models.HistoriqueAcces> HA;
        public HistoriqueAccesService()
        {
            dataModel = new DataModel();
            HA = new List<HistoriqueAcces>();
        }
        public List<Models.HistoriqueAcces> Get(profile Profile)
        {
            //

            A = dataModel.Profiles.Where(l => l.Name == Profile.Name).Include(j => j.acces).ThenInclude((Acces G) => G.HistoriqueAcces).First().acces;
            foreach (Acces v in A)
            {
               try
                {
                    HA.Add(v.HistoriqueAcces.Last());
                }catch (Exception e)
                {
                    Console.Write(e);
                }
                
            }

            return A.First().HistoriqueAcces;
        }

        public IEnumerable<Models.HistoriqueAcces> GetByDate(Acces Acces, DateTime Date)
        {
            profile pro = dataModel.Profiles
                                    .Where(p => p == Acces.Profile)
                                    .Include(j => j.acces)
                                    .ThenInclude((Acces A) => A.HistoriqueAcces)
                                    .Where(t => t.acces.
                                        Where(l=> 
                                            l.Type== Acces.Type 
                                            && l.Identifiant== Acces.Identifiant
                                            && l.HistoriqueAcces
                                                    .Where(x=> 
                                                    x.Connexion.Day== Date.Day 
                                                    &&
                                                    x.Connexion.Month == Date.Month)
                                        !=null) 
                                    != null)
                                    .First();
            List<Acces> J = pro.acces;
            List<Models.HistoriqueAcces> HA = new List<Models.HistoriqueAcces>();
            foreach (Acces v in J)
            {
                HA.Add(v.HistoriqueAcces.Last());
            }

            return HA.AsEnumerable();
        }

        public IEnumerable<Models.HistoriqueAcces> GetByDate(profile Profile, DateTime date)
        {
            profile pro = dataModel.Profiles
                                   .Where(p => p == Profile)
                                   .Include(j => j.acces)
                                   .ThenInclude((Acces A) => A.HistoriqueAcces)
                                   .Where(t => t.acces.
                                        Where(l => 
                                        l.HistoriqueAcces
                                        .Where(x =>
                                        x.Connexion.Day == date.Day
                                        &&
                                        x.Connexion.Month == date.Month
                                        &&
                                        x.Connexion.Year == date.Year)
                                        != null)
                                    != null).First();
            List<Acces> J = pro.acces;
            List<Models.HistoriqueAcces> HA = new List<Models.HistoriqueAcces>();
            foreach (Acces v in J)
            {
                HA.AddRange(v.HistoriqueAcces);
            
            }

            return HA.AsEnumerable();
        }

        public Models.HistoriqueAcces GetLast(Acces Acces)
        {
            profile pro = dataModel.Profiles
                                    .Where(p => p == Acces.Profile)
                                    .Include(j => j.acces)
                                    .ThenInclude((Acces A) => A.HistoriqueAcces)
                                    .Where(t => t.acces.
                                     Where(l => l==Acces)
                                     != null).First();
            List<Acces> J = pro.acces;
            Models.HistoriqueAcces HA = new Models.HistoriqueAcces();
            foreach (Acces v in J)
            {
                if(v==Acces)
                {
                    HA = v.HistoriqueAcces.Last();
                }
                ;
            }

            return HA;
        }
    }
}
