using ServeurPandora.IService;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServeurPandora.Models;
using Microsoft.AspNet.Mvc;
using ServeurPandora.Controllers;
using System;

namespace ServeurPandora.Service
{
    public class Login : ILogin
    {
        [FromServices]
        DataModel dataModel { get; set; }
        [FromServices]
        ILogger<LoginController> Logger { get; set; }

        public Login()
        {
            dataModel =new DataModel();
        }
        public profile GetProfile(string Email, string Mdp)
        {
            
            profile profile= new profile();
            profile = dataModel.Profiles.Single(f => f.Email == Email && f.Mdp == Mdp);
         /*    try
                {
                    
                    dataModel.HisotirqueCOmpte.Add(new HistoriqueCompte { Connexion = DateTime.Today, Profile = profile, IDProfile = profile.ID });
                    try
                    {
                        dataModel.SaveChanges();
                    }catch(Exception G)
                    {
                        Console.WriteLine(G);
                    }
                
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e);
                    profile = new profile();
            }*/
      
            return profile;
        }
        public bool VerifProfile(string Email, string Mdp)
        {
            try
            {
                dataModel.Profiles.Single(f => f.Email == Email && f.Mdp == Mdp);
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
