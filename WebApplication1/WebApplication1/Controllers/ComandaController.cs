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
    public class ComandaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComandaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Comanda
        [HttpGet]
        public IEnumerable<ComandaModel> GetComandaModel()
        {
            return _context.Comenzi;
        }

        // GET: api/Comanda/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComandaModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comandaModel = await _context.Comenzi.FindAsync(id);

            if (comandaModel == null)
            {
                return NotFound();
            }

            return Ok(comandaModel);
        }

        // PUT: api/Comanda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComandaModel([FromRoute] Guid id, [FromBody] ComandaModel comandaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comandaModel.IdComanda)
            {
                return BadRequest();
            }

            _context.Entry(comandaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaModelExists(id))
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

        // POST: api/Comanda
        [HttpPost]
        public async Task<IActionResult> PostComandaModel([FromBody] ComandaModel comandaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comenzi.Add(comandaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComandaModel", new { id = comandaModel.IdComanda }, comandaModel);
        }

        // DELETE: api/Comanda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComandaModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comandaModel = await _context.Comenzi.FindAsync(id);
            if (comandaModel == null)
            {
                return NotFound();
            }

            _context.Comenzi.Remove(comandaModel);
            await _context.SaveChangesAsync();

            return Ok(comandaModel);
        }

        private bool ComandaModelExists(Guid id)
        {
            return _context.Comenzi.Any(e => e.IdComanda == id);
        }
    }
}