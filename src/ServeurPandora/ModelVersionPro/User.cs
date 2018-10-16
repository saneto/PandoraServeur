using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.ModelVersionPro
{
    public class User
    {
        [Key]
        public int IdUser { set; get; }
        public string Nom { set; get; }
        public string Email { set; get; }
        public string prenom { set; get; }
        public string Mdp { set; get; }

        public virtual List<ProfilePro> Profile { set; get; }
        public virtual List<HistoriqueComptePro> HistoriqueCompte { set; get; }

    }
}
