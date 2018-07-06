using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class OrderModel
    {
        [Key]
        public Guid IdOrder { get; set; }

        public int PaymentModel { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
