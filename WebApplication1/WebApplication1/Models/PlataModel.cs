using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PlataModel
    {
        [Key]
        public Guid IdPlata { get; set; }

        public enum MetodaDePlataType : byte
        {
            CardBancar = 0,
            Cash = 1,
            CreditPeViata = 2,
            Rinichi = 3
        }

        [Required]
        public MetodaDePlataType MetodaDePlata { get; set; }
    }
}
