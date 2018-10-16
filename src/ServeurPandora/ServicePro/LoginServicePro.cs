using ServeurPandora.IservicePRo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.ModelVersionPro;
using Microsoft.AspNet.Mvc;
using ServeurPandora.Models;
using ServeurPandora.Controllers;
using Microsoft.Extensions.Logging;

namespace ServeurPandora.ServicePro
{
    public class LoginServicePro : ILoginServicePro
    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<LoginController> Logger { get; set; }
        public LoginServicePro()
        {
            dataModel = new DataModel();
        }
        public User GetProfile(string Id, string Mdp)
        {
            User Us = new User();
            try
            {
                Us = dataModel.Users.First(f => f.Email == Id && f.Mdp == Mdp);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                Us = new User();
            }

            return Us;
        }

        public bool VerifProfile(string Id, string Mdp)
        {
            try
            {
                dataModel.Users.Single(f => f.Email == Id && f.Mdp == Mdp);
                return true;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
