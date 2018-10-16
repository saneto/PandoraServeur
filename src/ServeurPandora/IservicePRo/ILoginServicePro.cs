using ServeurPandora.ModelVersionPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.IservicePRo
{
    public interface ILoginServicePro
    {
        User GetProfile(string Id, string Mdp);
        bool VerifProfile(string Id, string Mdp);
    }
}
