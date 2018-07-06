using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PaymentModel
    {
        [Key]
        public Guid IdPayment { get; set; }

        public enum PaymentMethodType : byte
        {
            DebitCard = 0,
            Cash = 1,
            Cheque = 2,
            Kidney = 3,
            LifetimeCredit = 4
        }

        [Required]
        public PaymentMethodType PaymentMethod { get; set; }
    }
}
