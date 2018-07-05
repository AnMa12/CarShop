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
            _context.Plati.AddRange(new PlataModel[] {
                new PlataModel()
                {
                    MetodaDePlata = PlataModel.MetodaDePlataType.Cash
                }
            });
            _context.SaveChanges();
        }

        [HttpPost("Scenario2")]
        public void Scenario2()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Plati.AddRange(new PlataModel[] {
                new PlataModel()
                {
                    MetodaDePlata = PlataModel.MetodaDePlataType.Cash
                }
            });



            _context.Masini.AddRange(new MasinaModel[] {
                new MasinaModel() {
                    Pret = 7800,
                    Stoc = 3
                },
                new MasinaModel() {
                    Pret = 9200,
                    Stoc = 1
                },
                new MasinaModel() {
                    Pret = 400,
                    Stoc = 2
                },
                new MasinaModel() {
                    Pret = 8900,
                    Stoc = 7
                },
            });


            ;
            _context.SaveChanges();
        }
    }
}