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
    public class HistoriqueProfileControllerPro : Controller
    {
        [FromServices]
        public IHistoriqueCompteServicePro HCSP { get; set; }
        [HttpPost("{Profile}")]
        public IEnumerable<HistoriqueComptePro> Get([FromBody]User User)
        {

            return HCSP.GetAll(User);
        }

        [HttpPost("Last")]
        public HistoriqueComptePro GetLast([FromBody]User User)
        {
            return HCSP.GetHistoriqueCompte(User);
        }
        [HttpPost("Date")]
        public IEnumerable<HistoriqueComptePro> GetByDate([FromBody]User User, DateTime date)
        {
            return HCSP.GetByDate(User, date);
        }
    }
}
