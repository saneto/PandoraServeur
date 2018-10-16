using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ServeurPandora.IService;
using ServeurPandora.Service;
using ServeurPandora.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ServeurPandora.Controllers
{
    [Route("api/[controller]")]
    public class AccesController : Controller
    {
        // GET: api/values
        [FromServices]
        public IAcces _A { get; set; }
       
        [HttpPost("Add")]
        public void AddAcces([FromBody]Acces value)
        {
            _A.AddAcces(value);
        }
        [HttpPost("Get")]
        public Acces GetAcces([FromBody]string value)
        {
            return _A.GetAcces("", "", 0);
        }
        [HttpPost("GetByType")]
        public IEnumerable<Models.Acces> GetByType([FromBody]string value,int id)
        {
            return _A.GetAccesByType(value, id);
        }
        [HttpPost("GetAllAcces")]
        public IEnumerable<Models.Acces> GetALlAcces([FromBody]string value)
        {
            return _A.GetAllAcces(5);
        }
        [HttpPost("Remove")]
        public void Remove([FromBody]Acces Acces)
        {
           _A.Remove(Acces);
        }
        [HttpPost("UpdateAcces")]
        public void Update([FromBody]Acces Acces)
        {
            _A.UpdateAcces(Acces);
        }


    }
}
