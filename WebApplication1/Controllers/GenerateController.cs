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

        [HttpPost("PopulateCarts")]
        public void PopulateCarts()
        {
            _context.Database.EnsureCreated();

            _context.Cart.AddRange(new CartModel[]
            {
                new CartModel()
                {
                    Quantity = 2,
                    Car = new List<CarModel> {
                        new CarModel() {
                            Photo = "https://www.fridayimages.com/1180801932007150112/3GCUKSEC5FG171597.jpg",
                            Make = "Chevrolet",
                            Model = "Silverado",
                            Price = 40500,
                            Stock = 3
                        },
                        new CarModel() {
                            Photo = "https://www.fridayimages.com/1180801932007150112/3D7KS28C17G762066.jpg",
                            Make = "Dodge",
                            Model = "Ram",
                            Price = 19900,
                            Stock = 2
                        },
                    },
                },
                new CartModel()
                {
                    Quantity = 4,
                    Car = new List<CarModel> {
                        new CarModel() {
                            Photo = "https://www.fridayimages.com/1180801932007150112/3GCUKSEC5FG171597.jpg",
                            Make = "Chevrolet",
                            Model = "Silverado",
                            Price = 40500,
                            Stock = 3
                        },
                    },
                },
            });

            _context.SaveChanges();
        }

        [HttpPost("PopulateCars")]
        public void PopulateCars()
        {
            _context.Database.EnsureCreated();

            _context.Cars.AddRange(new CarModel[] {
                new CarModel() {
                    Photo = "https://www.fridayimages.com/1180801932007150112/3GCUKSEC5FG171597.jpg",
                    Make = "Chevrolet",
                    Model = "Silverado",
                    Price = 40500,
                    Stock = 3
                },
                new CarModel() {
                    Photo = "https://www.fridayimages.com/1180801932007150112/3D7KS28C17G762066.jpg",
                    Make = "Dodge",
                    Model = "Ram",
                    Price = 19900,
                    Stock = 2
                },
                new CarModel() {
                    Photo = "https://www.fridayimages.com/1180801932007150112/1FMFU18525LA06954.jpg",
                    Make = "Ford",
                    Model = "Explorer",
                    Price = 29500,
                    Stock = 1
                },
                new CarModel() {
                    Photo = "https://www.fridayimages.com/1180801932007150112/1FMCU9H94DUD53618.jpg",
                    Make = "Ford",
                    Model = "Explorer",
                    Price = 29500,
                    Stock = 1
                },
                new CarModel() {
                    Photo = "https://www.fridayimages.com/1180801932007150112/5N1AT2MV4FC818718.jpg",
                    Make = "Hyunday",
                    Model = "Santa",
                    Price = 19500,
                    Stock = 10
                },
                new CarModel() {
                    Photo = "https://www.fridayimages.com/1180801932007150112/3TMJU62N28M052209.jpg",
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