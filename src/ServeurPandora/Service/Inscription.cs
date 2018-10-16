using ServeurPandora.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ServeurPandora.Controllers;

namespace ServeurPandora.Service
{
    public class Inscription : IInscription
    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<InscriptionController> Logger { get; set; }
        public Inscription()
        {
            dataModel = new DataModel();
        }
        public void Add(profile profile)
        {
            
            dataModel.Profiles.Add(profile);
            try
            {
                dataModel.SaveChanges();
            }catch
            {

            }
        }

        public bool  Verification(profile profile)
        {
            profile pr = new profile();
            bool vref; 
            try{
                vref = false;
                    pr = dataModel.Profiles.First(f => f.Email == profile.Email);
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