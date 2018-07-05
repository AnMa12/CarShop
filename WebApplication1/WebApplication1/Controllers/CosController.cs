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
    public class CosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cos
        [HttpGet]
        public IEnumerable<CosModel> GetCosModel()
        {
            return _context.Cosuri;
        }

        // GET: api/Cos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCosModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cosModel = await _context.Cosuri.FindAsync(id);

            if (cosModel == null)
            {
                return NotFound();
            }

            return Ok(cosModel);
        }

        // PUT: api/Cos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCosModel([FromRoute] Guid id, [FromBody] CosModel cosModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cosModel.IdCos)
            {
                return BadRequest();
            }

            _context.Entry(cosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CosModelExists(id))
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

        // POST: api/Cos
        [HttpPost]
        public async Task<IActionResult> PostCosModel([FromBody] CosModel cosModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cosuri.Add(cosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCosModel", new { id = cosModel.IdCos }, cosModel);
        }

        // DELETE: api/Cos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCosModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cosModel = await _context.Cosuri.FindAsync(id);
            if (cosModel == null)
            {
                return NotFound();
            }

            _context.Cosuri.Remove(cosModel);
            await _context.SaveChangesAsync();

            return Ok(cosModel);
        }

        private bool CosModelExists(Guid id)
        {
            return _context.Cosuri.Any(e => e.IdCos == id);
        }
    }
}