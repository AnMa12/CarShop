using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CartModel
    {
        [Key]
        public Guid IdCart { get; set; }

        public List<CarModel> Car { get; set; }

        public int Quantity { get; set; }

    }
}
