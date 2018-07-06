using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CartModel
    {
        [Key]
        public Guid IdCart { get; set; }

        public CarModel Masina { get; set; }
        public int Cantitate { get; set; }

    }
}
