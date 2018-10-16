using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.IservicePRo;
using ServeurPandora.ModelVersionPro;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Mvc;
using ServeurPandora.Controllers;
using ServeurPandora.Models;

namespace ServeurPandora.ServicePro
{
    public class AccesServicePro : IAccesServicePro
    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<Controller> Logger { get; set; }
        public AccesServicePro()
        {
            dataModel = new DataModel();
        }
        public void AddAcces(AccesPro Acces)
        {
            dataModel.AccesPro.Add(Acces);
        }

        public AccesPro GetAcces(string Id,int Idprofile)
        {
            AccesPro c = new AccesPro();
            try
            {
                c = dataModel.AccesPro.Single(f => f.IdProfilePro == Idprofile && f.login == Id);
                return c;
            }
            catch
            {
                return c;
            }
        }

        public IEnumerable<AccesPro> GetAccesByType(string Id, int Idprofile)
        {
            var A = (from Acc in dataModel.AccesPro
                     where Acc.IdProfilePro == Idprofile && Acc.login == Id
                     select Acc).AsEnumerable();
            return A.AsEnumerable();
        }

        public IEnumerable<AccesPro> GetAllAcces(int Idprofile)
        {
            var A = (from Acc in dataModel.AccesPro
                     where Acc.IdProfilePro == Idprofile
                     select Acc).AsEnumerable();
            return A.AsEnumerable();
        }

        public void Remove(AccesPro Acces)
        {
           // AccesPro a = dataModel.AccesPro.Single(f => f == Acces);
            dataModel.AccesPro.Remove(Acces);
            dataModel.SaveChanges();
        }

        public void UpdateAcces(AccesPro Acces)
        {
            AccesPro a = dataModel.AccesPro.Single(f => f.login == Acces.login && f.IdAcces == Acces.IdAcces);
            dataModel.AccesPro.Remove(a);
            a = Acces;
            dataModel.AccesPro.Add(a);
            dataModel.SaveChanges();
        }
    }
}
