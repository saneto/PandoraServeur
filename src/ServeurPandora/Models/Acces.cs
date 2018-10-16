using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.Models
{
    public class Acces
    {
        public int AccesId { get; set; }
        public string Type { set; get; }
        public string Identifiant { set; get; }
        public string Mdp { set; get; }

        public int IDProfile { set; get; }
        public profile Profile { set; get; }
        public virtual List<HistoriqueAcces> HistoriqueAcces { set; get; }
    }
}
