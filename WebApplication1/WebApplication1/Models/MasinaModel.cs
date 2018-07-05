using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MasinaModel
    {
        [Key]
        public Guid IdMasina { get; set; }

        public string Model { get; set; }
        public string Marca { get; set; }
        public int Pret { get; set; }
        public int Stoc { get; set; }

    }
}
