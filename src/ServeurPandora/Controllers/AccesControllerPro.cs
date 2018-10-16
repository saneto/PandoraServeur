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
    public class AccesControllerPro : Controller
    {
        [FromServices]
        public IAccesServicePro ASP { get; set; }

        [HttpPost("Add")]
        public void AddAcces([FromBody]AccesPro value)
        {
            ASP.AddAcces(value);
        }

        [HttpPost("Get")]
        public AccesPro GetAcces([FromBody]string ID,int idprofile)
        {
            return ASP.GetAcces(ID, idprofile);
        }
        [HttpPost("GetByType")]
        public IEnumerable<AccesPro> GetByType([FromBody]string value, int id)
        {
            return ASP.GetAccesByType(value, id);
        }
        [HttpPost("GetAllAcces")]
        public IEnumerable<AccesPro> GetALlAcces([FromBody]int Idprofile)
        {
            return ASP.GetAllAcces(Idprofile);
        }
        [HttpPost("Remove")]
        public void Remove([FromBody]AccesPro Acces)
        {
            ASP.Remove(Acces);
        }
        [HttpPost("UpdateAcces")]
        public void Update([FromBody]AccesPro Acces)
        {
            ASP.UpdateAcces(Acces);
        }
    }
}
