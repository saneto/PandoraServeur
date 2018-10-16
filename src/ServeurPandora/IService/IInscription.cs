using ServeurPandora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.IService
{
    public interface IInscription
    {
        bool Verification(profile profile);
        void Add(profile profile);
    }
}
