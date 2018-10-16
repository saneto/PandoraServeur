using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.ModelVersionPro;
namespace ServeurPandora.IservicePRo
{
    public interface IAccesServicePro
    {
        void AddAcces(AccesPro Acces);
        void Remove(AccesPro Acces);
        AccesPro GetAcces(string Id,  int Idprofile);
        void UpdateAcces(AccesPro Acces);
        IEnumerable<AccesPro> GetAccesByType(string Id, int Idprofile);
        IEnumerable<AccesPro> GetAllAcces(int Idprofile);
        
    }
}
