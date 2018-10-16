using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ServeurPandora.IservicePRo;
using ServeurPandora.ModelVersionPro;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ServeurPandora.Controllers
{
    [Route("api/[controller]")]
    public class LoginControllerPro : Controller
    {
        [FromServices]
        public ILoginServicePro LSP {set; get;}
        [HttpPost("Connexion")]
        public User get([FromBody]string Id, string Mdp)
        {

            User p2 = new User();
            p2 = LSP.GetProfile(Id, Mdp);
            return p2;

        }
        [HttpPost("Verification")]
        public bool verifMdp([FromBody]string Id, string Mdp)
        {
            return LSP.VerifProfile(Id, Mdp);
        }
    }
}
