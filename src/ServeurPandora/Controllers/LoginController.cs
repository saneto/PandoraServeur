using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ServeurPandora.Models;
using System.Web.Http.Cors;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using ServeurPandora.IService;
using ServeurPandora.Service;
namespace ServeurPandora.Controllers
{

    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        /*[FromServices]
        public DataModel DataModel { get; set; }
        [FromServices]
        public ILogger<ValuesController> Logger { get; set; } */
        [FromServices]
        public ILogin Login { get; set; }
        profile p2 = new profile();
        [HttpGet]
        public profile get()
        {
           // p = new Login();
            
            profile p2= new profile();
            p2 = Login.GetProfile("jn", "12qsddq3");
            return p2;

        }
        [HttpPost("Connexion")]
        public profile get([FromBody]profile p)
        {
            if(p!=null)
            {
        
             p2 = Login.GetProfile(p.Email, p.Mdp);
            return p2;
            }
            return null;

        }
        [HttpPost("Verification")]
        public bool verifMdp([FromBody]profile p)
        {
            return Login.VerifProfile(p.Email, p.Mdp);
        }
    }
}
