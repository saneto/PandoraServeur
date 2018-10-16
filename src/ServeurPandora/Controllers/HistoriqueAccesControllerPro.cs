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
    public class HistoriqueAccesControllerPro : Controller
    {
        [FromServices]
        public IHistoriqueAccesServicePro HASP { get; set; }

        [HttpPost("GetALl")]
        public IEnumerable<HistoriqueAccesPro> Get([FromBody]User User)
        {
            return HASP.Get(User);
        }

        [HttpPost("GetLast")]
        public HistoriqueAccesPro GetLast([FromBody]AccesPro AccesPro)
        {
            return HASP.GetLast(AccesPro);
        }
        [HttpPost("GetAccesDate")]
        public IEnumerable<HistoriqueAccesPro> GetByDate([FromBody]AccesPro AccesPro, DateTime date)
        {
            return HASP.GetByDate(AccesPro, date);
        }

        [HttpPost("GetAllAccesDate")]
        public IEnumerable<HistoriqueAccesPro> GetByDate([FromBody]User User, DateTime date)
        {
            return HASP.GetByDate(User, date);
        }
        [HttpPost("GetAllByProfile")]
        public IEnumerable<HistoriqueAccesPro> GetByProfile([FromBody]ProfilePro Pro)
        {
            return HASP.GetByProfile(Pro);
        }
    }
}
