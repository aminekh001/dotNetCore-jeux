using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jeuxVedio.Data;
using jeuxVedio.Models;

namespace jeuxVedio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackpacksController : ControllerBase
    {
        private readonly DataContext _context;

        public BackpacksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Backpacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Backpack>>> GetBackpacks()
        {
          if (_context.Backpacks == null)
          {
              return NotFound();
          }
            return await _context.Backpacks.ToListAsync();
        }

        // GET: api/Backpacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Backpack>> GetBackpack(int id)
        {
          if (_context.Backpacks == null)
          {
              return NotFound();
          }
            var backpack = await _context.Backpacks.FindAsync(id);

            if (backpack == null)
            {
                return NotFound();
            }

            return backpack;
        }

        // PUT: api/Backpacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBackpack(int id, Backpack backpack)
        {
            if (id != backpack.Id)
            {
                return BadRequest();
            }

            _context.Entry(backpack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BackpackExists(id))
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

        // POST: api/Backpacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Backpack>> PostBackpack(Backpack backpack)
        {
          if (_context.Backpacks == null)
          {
              return Problem("Entity set 'DataContext.Backpacks'  is null.");
          }
            _context.Backpacks.Add(backpack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBackpack", new { id = backpack.Id }, backpack);
        }

        // DELETE: api/Backpacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBackpack(int id)
        {
            if (_context.Backpacks == null)
            {
                return NotFound();
            }
            var backpack = await _context.Backpacks.FindAsync(id);
            if (backpack == null)
            {
                return NotFound();
            }

            _context.Backpacks.Remove(backpack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BackpackExists(int id)
        {
            return (_context.Backpacks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
