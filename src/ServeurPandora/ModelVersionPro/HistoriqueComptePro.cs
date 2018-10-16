using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServeurPandora.ModelVersionPro
{
    public class HistoriqueComptePro
    {

        [Key]
        public int IdHistorique { get; set; }
        public DateTime Connexion { get; set; }
        public DateTime Deconnexion { get; set; }

        public int IDUser { set; get; }
        public User User { set; get; }


    }
}
