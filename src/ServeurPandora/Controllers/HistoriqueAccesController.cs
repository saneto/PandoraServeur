using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ServeurPandora.Models;
using ServeurPandora.Service;
using ServeurPandora.IService;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ServeurPandora.Controllers
{
    [Route("api/[controller]")]
    public class HistoriqueAccesController : Controller
    {

        [FromServices]
        public  IHistoriqueAcces HA { get; set; }
        [HttpPost("GetALl")]
        public IEnumerable<HistoriqueAcces> Get(profile Profile)
        {
            //   return HA.Get(Profile);
            return null;
        }

        [HttpGet("GetLast")]
        public HistoriqueAcces GetLast(Acces Acces)
        {
            return HA.GetLast(Acces);
        }
        [HttpGet("GetAccesDate")]
        public IEnumerable<HistoriqueAcces> GetByDate(Acces Acces, DateTime date)
        {
            return HA.GetByDate(Acces,date);
        }
        
        [HttpGet("GetAllAccesDate")]
        public IEnumerable<HistoriqueAcces> GetLast(profile Profile, DateTime date)
        {
            return HA.GetByDate(Profile, date);
        }
    }
}
