using ServeurPandora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.IService
{
    public interface IAcces
    {
        void AddAcces(Acces Acces);
        void Remove(Acces Acces);
        Acces GetAcces(string Id, string type,int Idprofile);
        void UpdateAcces(Acces Acces);
        IEnumerable<Acces> GetAccesByType(string type, int Idprofile);
        IEnumerable<Acces> GetAllAcces( int Idprofile);
    }
}
