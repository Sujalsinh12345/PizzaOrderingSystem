using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingSystem.Models;

namespace PizzaOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingsController : ControllerBase
    {
        private readonly PizzaOrderingSystemContext _context;

        public ToppingsController(PizzaOrderingSystemContext context)
        {
            _context = context;
        }

        // GET: api/Toppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topping>>> GetToppings()
        {
            var top = await _context.Toppings.ToListAsync();
            return Ok(new
            {
                success = true,
                top
            });
        }

        // GET: api/Toppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topping>> GetTopping(int id)
        {
            var topping = await _context.Toppings.FindAsync(id);

            if (topping == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                success = true,
                topping
            });
        }

        // PUT: api/Toppings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopping(int id, Topping topping)
        {
            if (id != topping.ToppingId)
            {
                return BadRequest();
            }

            _context.Entry(topping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToppingExists(id))
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

        // POST: api/Toppings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Topping>> PostTopping(Topping topping)
        {
            _context.Toppings.Add(topping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopping", new { id = topping.ToppingId }, topping);
        }

        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopping(int id)
        {
            var topping = await _context.Toppings.FindAsync(id);
            if (topping == null)
            {
                return NotFound();
            }

            _context.Toppings.Remove(topping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToppingExists(int id)
        {
            return _context.Toppings.Any(e => e.ToppingId == id);
        }
    }
}
