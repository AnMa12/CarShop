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
    public class MasinaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MasinaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Masina
        [HttpGet]
        public IEnumerable<MasinaModel> GetMasinaModel()
        {
            return _context.Masini;
        }

        // GET: api/Masina/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMasinaModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var masinaModel = await _context.Masini.FindAsync(id);

            if (masinaModel == null)
            {
                return NotFound();
            }

            return Ok(masinaModel);
        }

        // PUT: api/Masina/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasinaModel([FromRoute] Guid id, [FromBody] MasinaModel masinaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != masinaModel.idMasina)
            {
                return BadRequest();
            }

            _context.Entry(masinaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasinaModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Masina
        [HttpPost]
        public async Task<IActionResult> PostMasinaModel([FromBody] MasinaModel masinaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Masini.Add(masinaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasinaModel", new { id = masinaModel.idMasina }, masinaModel);
        }

        // DELETE: api/Masina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasinaModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var masinaModel = await _context.Masini.FindAsync(id);
            if (masinaModel == null)
            {
                return NotFound();
            }

            _context.Masini.Remove(masinaModel);
            await _context.SaveChangesAsync();

            return Ok(masinaModel);
        }

        private bool MasinaModelExists(Guid id)
        {
            return _context.Masini.Any(e => e.idMasina == id);
        }
    }
}