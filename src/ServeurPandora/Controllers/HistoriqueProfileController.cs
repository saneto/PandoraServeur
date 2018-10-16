using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ServeurPandora.Service;
using ServeurPandora.IService;
using ServeurPandora.Models;

namespace ServeurPandora.Controllers
{
    [Route("api/[controller]")]
    public class HistoriqueProfileController : Controller
    {
        [FromServices]
        public IHistoriqueCompte HC { get; set; }

        [HttpPost("{Profile}")]
        public IEnumerable<HistoriqueCompte> Get([FromBody]profile Profile)
        {
            
            return HC.GetAll(Profile);
        }

        [HttpPost("Last")]
        public HistoriqueCompte GetLast([FromBody]profile Profile)
        {
            return HC.GetHistoriqueCompte(Profile);
        }
        [HttpPost("Date")]
        public IEnumerable<HistoriqueCompte> GetByDate([FromBody]profile Profile, DateTime date)
        {
            return HC.GetByDate(Profile, date);
        }
    }
}
