using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.Models
{
    public class HistoriqueAcces
    {
        [Key]
        public int IdHistorique { get; set; }
        public DateTime Connexion { get; set; }
        public DateTime Deconnexion { get; set; }

        public int IdAcces { get; set; }
        public Acces Acces { get; set; }
    }
}
