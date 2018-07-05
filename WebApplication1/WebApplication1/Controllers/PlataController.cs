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
    public class PlataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Plata
        [HttpGet]
        public IEnumerable<PlataModel> GetPlati()
        {
            return _context.Plati;
        }

        // GET: api/Plata/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlataModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plataModel = await _context.Plati.FindAsync(id);

            if (plataModel == null)
            {
                return NotFound();
            }

            return Ok(plataModel);
        }

        // PUT: api/Plata/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlataModel([FromRoute] Guid id, [FromBody] PlataModel plataModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plataModel.IdPlata)
            {
                return BadRequest();
            }

            _context.Entry(plataModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlataModelExists(id))
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

        // POST: api/Plata
        [HttpPost]
        public async Task<IActionResult> PostPlataModel([FromBody] PlataModel plataModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Plati.Add(plataModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlataModel", new { id = plataModel.IdPlata }, plataModel);
        }

        // DELETE: api/Plata/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlataModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plataModel = await _context.Plati.FindAsync(id);
            if (plataModel == null)
            {
                return NotFound();
            }

            _context.Plati.Remove(plataModel);
            await _context.SaveChangesAsync();

            return Ok(plataModel);
        }

        private bool PlataModelExists(Guid id)
        {
            return _context.Plati.Any(e => e.IdPlata == id);
        }
    }
}