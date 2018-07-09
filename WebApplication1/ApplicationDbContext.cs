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

        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CarModel> Cars { get; set; }

        internal ApplicationDbContext Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public DbSet<CartModel> Cart { get; set; }
    }
}
