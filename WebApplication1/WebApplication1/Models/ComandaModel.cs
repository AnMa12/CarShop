using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ComandaModel
    {
        [Key]
        public Guid IdComanda { get; set; }

        public PlataModel Plata { get; set; }
        private string adresaLivrare;

        public string GetAdresaLivrare()
        {
            return adresaLivrare;
        }

        public void SetAdresaLivrare(string value)
        {
            adresaLivrare = value;
        }
    }
}
