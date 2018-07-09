using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

namespace CarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cart
        [HttpGet]
        public IEnumerable<CartModel> GetCart()
        {
            return _context.Cart.Include(c => c.Car);
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartModel = await _context.Cart.FindAsync(id);

            if (cartModel == null)
            {
                return NotFound();
            }

            return Ok(cartModel);
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartModel([FromRoute] Guid id, [FromBody] CartModel cartModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartModel.IdCart)
            {
                return BadRequest();
            }

            _context.Entry(cartModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartModelExists(id))
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

        // POST: api/Cart
        [HttpPost]
        public async Task<IActionResult> PostCartModel([FromBody] CartModel cartModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cart.Add(cartModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartModel", new { id = cartModel.IdCart }, cartModel);
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartModel = await _context.Cart.FindAsync(id);
            if (cartModel == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cartModel);
            await _context.SaveChangesAsync();

            return Ok(cartModel);
        }

        private bool CartModelExists(Guid id)
        {
            return _context.Cart.Any(e => e.IdCart == id);
        }
    }
}