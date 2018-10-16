using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServeurPandora.Models;
using System.ComponentModel.DataAnnotations;

namespace ServeurPandora.Models
{
    public class HistoriqueCompte
    {

        [Key]
        public int IdHistorique { get; set; }
        public DateTime Connexion { get; set; }
        public DateTime Deconnexion { get; set; }
        public int IDProfile { set; get; }
        public profile Profile { set; get; }


    }
}
