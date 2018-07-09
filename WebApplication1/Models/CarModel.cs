using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CarModel
    {
        [Key]
        public Guid IdCar { get; set; }

        public string Photo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

    }
}
