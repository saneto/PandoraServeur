using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Entity;
using ServeurPandora.Models;
namespace ServeurPandora.Models
{
    public class profile
    {
        [Key]
        public int ID{ get; set; }
        public string Name { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Mdp{ get; set; }
        public virtual List<Acces> acces { get; set; }


        public virtual List<HistoriqueCompte> HistoriqueCompte { set; get; }
    }
}
