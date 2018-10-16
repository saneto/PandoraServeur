using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ServeurPandora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.IService
{
    public interface ILogin
    {
        profile GetProfile(string Id, string Mdp);
        bool VerifProfile(string Id, string Mdp);
    }
}
