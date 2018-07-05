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
        public string AdresaLivrare { get; set; }
    }
}
