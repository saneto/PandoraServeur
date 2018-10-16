using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ServeurPandora.IService;
using ServeurPandora.Service;
using ServeurPandora.Models;

namespace ServeurPandora.Controllers
{
    [Route("api/[controller]")]
    public class InscriptionController : Controller
    {
        [FromServices]
        public IInscription p2 { get; set; }
        [HttpPost]
        public bool Post([FromBody]profile p)
        {
            if(p!=null)
            {
            if (p2.Verification(p))
            {
                p2.Add(p);
                return true;
            }
            else
            {
                return false;
            }
            }
            return false;
        }
       
    }
}
