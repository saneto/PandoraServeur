using ServeurPandora.ModelVersionPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.IservicePRo
{
    public interface IInscriptionServicePro
    {
        bool Verification(User User);
        void Add(User User);
    }
}
