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
        public Guid idMasina { get; set; }

        private string Model;
        private string Marca;
        public int Pret { get; set; }
        public int Stoc { get; set; }

        public string GetMarca()
        {
            return Marca;
        }

        public void SetMarca(string value)
        {
            Marca = value;
        }

        public string GetNume()
        {
            return Model;
        }

        public void SetNume(string value)
        {
            Model = value;
        }

    }
}
