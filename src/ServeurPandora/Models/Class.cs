using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.Models
{
    public static class Class
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<DataModel>();
           if (!context.Acces.Any())
            {
                var t= context.Profiles.Add(
                        new profile { Name = "tosqdqdsdto", Prenom = "qsqdsqdsx", Email = "qsdqsqdd@qd.fr", Mdp = "12qsddq3", acces = new List<Acces> { new Acces { Identifiant = "sddtoto", Type = "dkqsddssdk", Mdp = "qsdddsd" }, new Acces { Identifiant = "toto", Type = "dkqsdk", Mdp = "qsd"} } }).Entity;

                context.SaveChanges();
            }
            if (!context.HisotirqueAcces.Any())
            {
              //  var t = context.Profiles.Add(
                //        new profile { Name = "tosqdqdsdto", Prenom = "qsqdsqdsx", Email = "qsdqsqdd@qd.fr", Mdp = "12qsddq3", acces = new List<Acces> { new Acces { Identifiant = "sddtoto", Type = "dkqsddssdk", Mdp = "qsdddsd" }, new Acces { Identifiant = "toto", Type = "dkqsdk", Mdp = "qsd" } } }).Entity;
                context.HisotirqueAcces.Add(new HistoriqueAcces { Connexion = DateTime.Today, IdAcces = 1 });
                context.HisotirqueAcces.Add(new HistoriqueAcces { Connexion = DateTime.Today, IdAcces = 1 });

                context.SaveChanges();
            }
        }
        }
    }
