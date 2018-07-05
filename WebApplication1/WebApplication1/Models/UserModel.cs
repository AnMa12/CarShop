using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserModel
    {
        [Key]
        public Guid IdUser { get; set; }

        public string Login { get; set; }
        public string Parola { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }
    }
}
