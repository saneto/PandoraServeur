using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.ModelVersionPro
{
    public class HistoriqueAccesPro
    {
        [Key]
        public int IdHistorique { get; set; }
        public DateTime Connexion { get; set; }
        public DateTime Deconnexion { get; set; }

        public int IdAccesPro { get; set; }
        public AccesPro Acces { get; set; }
    }
}
