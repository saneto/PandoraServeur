using ServeurPandora.IservicePRo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.ModelVersionPro;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ServeurPandora.Models;

namespace ServeurPandora.ServicePro
{
    public class InscriptionServicePRo : IInscriptionServicePro
    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<Controller> Logger { get; set; }
        public InscriptionServicePRo()
        {
            dataModel = new DataModel();
        }
        public void Add(User User)
        {
            dataModel.Users.Add(User);
            try
            {
                dataModel.SaveChanges();
            }
            catch
            {

            }
        }

        public bool Verification(User User)
        {
            User us = new User();
            bool vref;
            try
            {
                vref = false;
                us = dataModel.Users.First(f => f.Email == User.Email);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return true;
            }
            return vref;
        }
    }
}
