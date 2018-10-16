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
    public class InscriptionControllerPro : Controller
    {

        [FromServices]
        public IInscriptionServicePro ISP { get; set; }
        [HttpPost]
        public bool Post([FromBody]User p)
        {
            if (ISP.Verification(p))
            {
                ISP.Add(p);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
