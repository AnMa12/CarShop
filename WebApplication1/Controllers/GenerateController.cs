using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenerateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Scenario1")]
        public void Scenario1()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.Payments.AddRange(new PaymentModel[] {
                new PaymentModel()
                {
                    PaymentMethod = PaymentModel.PaymentMethodType.Cash
                }
            });

            _context.SaveChanges();
        }

        [HttpPost("PopulatePayments")]
        public void PopulatePayments()
        {
            _context.Database.EnsureCreated();

            _context.Payments.AddRange(new PaymentModel[] {
                new PaymentModel()
                {
                    PaymentMethod = PaymentModel.PaymentMethodType.Cash
                }
            });

            _context.SaveChanges();
        }

        [HttpPost("PopulateUsers")]
        public void PopulateUsers()
        {
            _context.Database.EnsureCreated();

            _context.Users.AddRange(new UserModel[]
            {
                new UserModel()
                {
                    FirstName = "Paulina",
                    LastName = "Kunibert",
                    Login = "user",
                    Password = "user",
                    Email = "user@mail.com",
                    Phone = "01234567890"
                },
                new UserModel()
                {
                    FirstName = "Mihael",
                    LastName = "Niraj",
                    Login = "user",
                    Password = "user",
                    Email = "user@mail.com",
                    Phone = "01234567890"
                },
                new UserModel()
                {
                    FirstName = "Karl",
                    LastName = "Melia",
                    Login = "user",
                    Password = "user",
                    Email = "user@mail.com",
                    Phone = "01234567890"
                }
            });

            _context.SaveChanges();
        }


        [HttpPost("PopulateOrders")]
        public void PopulateOrders()
        {
            _context.Database.EnsureCreated();
           
            //exista cumva metoda sa faci get pe idu unei masini???

            _context.SaveChanges();
        }


        [HttpPost("PopulateCars")]
        public void PopulateCars()
        {
            _context.Database.EnsureCreated();

            _context.Cars.AddRange(new CarModel[] {
                new CarModel() {
                    Make = "Chevrolet",
                    Model = "Silverado",
                    Price = 40500,
                    Stock = 3
                },
                new CarModel() {
                    Make = "Dodge",
                    Model = "Ram",
                    Price = 19900,
                    Stock = 2
                },
                new CarModel() {
                    Make = "Ford",
                    Model = "Explorer",
                    Price = 29500,
                    Stock = 1
                },
                new CarModel() {
                    Make = "Ford",
                    Model = "Explorer",
                    Price = 29500,
                    Stock = 1
                },
                new CarModel() {
                    Make = "Hyunday",
                    Model = "Santa",
                    Price = 19500,
                    Stock = 10
                },
                new CarModel() {
                    Make = "Toyota",
                    Model = "Tacoma",
                    Price = 19500,
                    Stock = 5
                }
            });

            _context.SaveChanges();
        }
    }
}