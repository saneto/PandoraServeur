
using ServeurPandora.Models;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ServeurPandora.IService;
using ServeurPandora.Models;
using ServeurPandora.Service;

namespace ServeurPandora.Controllers
{
    
    [Route("api/[controller]")]

    public class ValuesController : Controller
    {
       // [FromServices]
       // public DataModel DataModel { get; set; }
       // [FromServices]
        //public ILogger<ValuesController> Logger { get; set; }
        public static List<Acces> a= new List<Acces>();
        List<HistoriqueAcces> A = new List<HistoriqueAcces>();

        HistoriqueAcces k = new HistoriqueAcces();
        [FromServices]
        public IAcces _A { get; set; }
        [FromServices]
        public IHistoriqueAcces HA { get; set; }
        [HttpGet]
        public HistoriqueAcces Getk()
         {
            
            profile pro = new profile();
            pro.Name = "tosqdqdsdto";
            pro.Prenom = "qsqdsqdsx";
           
            A= HA.Get(pro);
            k= A.First();

            return k;
        }
        /* [HttpGet("{Id}")]
         public List<Acces> Get()
          {
             //  profile pro = DataModel.Profiles.Single(f => f.Id == "azqsdqde");
             //var c = DataModel.Profiles.Where(f => f.ID == 1).Include(a => a.acces).Select(v=>v.acces).ToList();

             return a;
         }  */
        /*   public string Ge2t(profile id)
           {
               var c = from p2 in DataModel.Profiles
                       where p2.Email == id.Email && p2.Mdp == id.Mdp
                       select p2.Email;
               if(id.Email == null)
               return "toto";
               else { return "OK"; }


           }
            // GET api/values/5)
           public profile Ge1t(int id)
           {

               var t = DataModel.Profiles.Include(b => b.Mdp);
               profile pro = DataModel.Profiles.Single(f => f.Email == "9850005545454");
               if (t==null)
               {
                   return pro;
               }
               else
               {
                   return pro;
               }

           }
           public string Gettoto()
           {
               profile pro = new profile { Name = "tosqdsqdqsdqdsdto", Prenom = "qsqdsqsdsqdqdsx", Email = "qsdqsdqdqsdqdqsqsqdd@qd.fr", Mdp = "12qsddq3" };
               DataModel.Profiles.Add(pro);
               DataModel.SaveChangesAsync();
               return "TOTO";
           }
           public string Gettoto(profile id)
           {
               profile p1= new profile {Name = id.Name, Prenom = id.Prenom, Email = id.Email, Mdp = id.Mdp };
               var v = from i in DataModel.Profiles
                       where  i.Email == id.Email
                       select i;
                DataModel.Profiles.Add(p1);
                   DataModel.SaveChanges();
                   return "Ok";

           }
           // POST api/values


           [HttpPost]
           public bool Post([FromBody]profile value)
           {

               if (value != null)
               {
                   profile p1 = new profile {  Name = "qsdqssssdqsds", Prenom = "sqdsqqqdqqd", Email = "sqsdddddxc", Mdp = "sqdwddddqww" };

                   // profile p1 = new profile { Id = valuer.Id, Name = valuer.Name, Prenom = valuer.Prenom, Email = valuer.Email, Mdp = valuer.Mdp };*/
        /*var v = from i in DataModel.Profiles
                where i.Id == valuer.Id && i.Email == valuer.Email
                select i;*/
        /*        DataModel.Profiles.Add(p1);
                DataModel.SaveChanges();
                return true;
            }
            else
            {
                profile p1 = new profile { Name = "qsdqsss", Prenom = "sqdqqd", Email = "sqddxc", Mdp = "sqdwww" };
                DataModel.Profiles.Add(p1);
                try
                {
                    DataModel.SaveChanges();
                }catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return false;
            }
        }*/
        //[HttpPost("{id}")]
        /*public void Post1([FromBody]profile valuer)
        {
            if (valuer != null)
            {
                profile p1 = new profile { Id = valuer.Id, Name = valuer.Name, Prenom = valuer.Prenom, Email = valuer.Email, Mdp = valuer.Mdp };
                var v = from i in DataModel.Profiles
                        where i.Id == valuer.Id && i.Email == valuer.Email
                        select i;*/
        /* DataModel.Profiles.Add(p1);
         DataModel.SaveChanges();
     }
     else
     {
         profile p1 = new profile { Id = "sqd", Name = "qsdq", Prenom = "sqd", Email = "sqd", Mdp = "sqd" };
         DataModel.Profiles.Add(p1);
         DataModel.SaveChanges();
     }

 }*/
    }
}
