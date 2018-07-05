﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CosModel
    {
        [Key]
        public Guid IdCos { get; set; }

        public MasinaModel masina { get; set; }
        public int cantitate { get; set; }

    }
}