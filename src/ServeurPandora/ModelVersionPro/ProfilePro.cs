using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServeurPandora.ModelVersionPro
{
    public class ProfilePro
    {
        [Key]
        public int IdProfilePro { set; get; }
        public string nom { set; get; }
        public int IdUser { set; get; }
        public virtual List<AccesPro> Acces { set; get; }

    }
}
