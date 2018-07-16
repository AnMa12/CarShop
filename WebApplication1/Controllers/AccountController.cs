using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarShop.Models;
using WebApplication1;

namespace CarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public IEnumerable<AccountModel> GetAccountModel()
        {
            return _context.Account;
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountModel = await _context.Account.FindAsync(id);

            if (accountModel == null)
            {
                return NotFound();
            }

            return Ok(accountModel);
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountModel([FromRoute] Guid id, [FromBody] AccountModel accountModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountModel.IdAccount)
            {
                return BadRequest();
            }

            _context.Entry(accountModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountModelExists(id))
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

        // POST: api/Account
        [HttpPost]
        public async Task<IActionResult> PostAccountModel([FromBody] AccountModel accountModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Account.Add(accountModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountModel", new { id = accountModel.IdAccount }, accountModel);
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountModel = await _context.Account.FindAsync(id);
            if (accountModel == null)
            {
                return NotFound();
            }

            _context.Account.Remove(accountModel);
            await _context.SaveChangesAsync();

            return Ok(accountModel);
        }

        private bool AccountModelExists(Guid id)
        {
            return _context.Account.Any(e => e.IdAccount == id);
        }
    }
}