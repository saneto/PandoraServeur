using ServeurPandora.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.Models;
using Microsoft.Extensions.Logging;
using ServeurPandora.Controllers;
using Microsoft.AspNet.Mvc;

namespace ServeurPandora.Service
{
    public class AccesService : IAcces
    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<AccesController> Logger { get; set; }
        public AccesService()
        {
            dataModel = new DataModel();
        }
        public void AddAcces(Models.Acces Acces)
        {
            dataModel.Acces.Add(Acces);
        }
        public Models.Acces GetAcces(string Id, string type,int Idprofile)
        {
            Models.Acces c = new Models.Acces();
            try
            {
                c = dataModel.Acces.Single(f => f.Type == type && f.IDProfile== Idprofile && f.Identifiant == Id);
                return c;
            }catch
            {
                return c;
            }
        }

        public IEnumerable<Models.Acces> GetAccesByType(string type,int Idprofile)
        {
            var A = (from Acc in dataModel.Acces
                     where Acc.Type == type && Acc.IDProfile == Idprofile
                     select Acc).AsEnumerable();
            return A.AsEnumerable();
        }

        public IEnumerable<Models.Acces> GetAllAcces( int Idprofile)
        {
            var A = (from Acc in dataModel.Acces
                     where Acc.IDProfile == Idprofile
                     select Acc).AsEnumerable();
            return A.AsEnumerable();
        }

        public void Remove(Models.Acces Acces)
        {
            Acces a= dataModel.Acces.Single(f => f.Identifiant == Acces.Identifiant && f.Type == Acces.Type && f.Mdp == Acces.Mdp);
            dataModel.Acces.Remove(Acces);
            dataModel.SaveChanges();
        }

        public void UpdateAcces(Models.Acces Acces)
        {
            //throw new NotImplementedException();
            Acces a = dataModel.Acces.Single(f => f.Identifiant == Acces.Identifiant && f.Type == Acces.Type && f.IDProfile == Acces.IDProfile);
            dataModel.Acces.Remove(a);
            a.Mdp = Acces.Mdp;
            dataModel.Acces.Add(a);
            dataModel.SaveChanges();
        }
    }
}
