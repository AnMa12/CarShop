using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required, DefaultValue("[]")]
        public string Cars { get; set; }

        [NotMapped]
        public List<Guid> CarIds
            {
            get => JsonConvert.DeserializeObject<List<Guid>>(Cars);
            set => Cars = JsonConvert.SerializeObject(value);
        }
    }
}
