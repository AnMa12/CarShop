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
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Payment
        [HttpGet]
        public IEnumerable<PaymentModel> GetPayments()
        {
            return _context.Payments;
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentModel = await _context.Payments.FindAsync(id);

            if (paymentModel == null)
            {
                return NotFound();
            }

            return Ok(paymentModel);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentModel([FromRoute] Guid id, [FromBody] PaymentModel paymentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentModel.IdPayment)
            {
                return BadRequest();
            }

            _context.Entry(paymentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentModelExists(id))
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

        // POST: api/Payment
        [HttpPost]
        public async Task<IActionResult> PostPaymentModel([FromBody] PaymentModel paymentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Payments.Add(paymentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentModel", new { id = paymentModel.IdPayment }, paymentModel);
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentModel = await _context.Payments.FindAsync(id);
            if (paymentModel == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(paymentModel);
            await _context.SaveChangesAsync();

            return Ok(paymentModel);
        }

        private bool PaymentModelExists(Guid id)
        {
            return _context.Payments.Any(e => e.IdPayment == id);
        }
    }
}