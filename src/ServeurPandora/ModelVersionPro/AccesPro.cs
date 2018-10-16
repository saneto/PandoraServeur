using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.ModelVersionPro
{
    public class AccesPro
    {
        [Key]
        public int IdAcces { set; get; }
        public string login { set; get; }
        public string Mdp { set; get; }
        public int IdProfilePro { set; get; }
        public ProfilePro Profile { set; get; }
        public virtual List<HistoriqueAccesPro> HisotriqueAccesPro { set; get; }
    }
}
