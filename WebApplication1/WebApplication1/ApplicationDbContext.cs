using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PlataModel> Plati { get; set; }

        public DbSet<ComandaModel> Comenzi { get; set; }

        public DbSet<UserModel> Useri { get; set; }
  
        public DbSet<MasinaModel> Masini { get; set; }

        public DbSet<CosModel> Cosuri { get; set; }
    }
}
