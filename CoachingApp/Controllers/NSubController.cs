using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoachingApp.Implementations;
using CoachingApp.Models;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NSubController : ControllerBase
    {
        private readonly IdentityApplicationContext _context;

        public NSubController(IdentityApplicationContext context)
        {
            _context = context;
        }

        // GET: api/NSub
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nutrition_Subscription>>> GetNutrition_Subscriptions()
        {
          if (_context.Nutrition_Subscriptions == null)
          {
              return NotFound();
          }
            return await _context.Nutrition_Subscriptions.ToListAsync();
        }

        // GET: api/NSub/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nutrition_Subscription>> GetNutrition_Subscription(int id)
        {
          if (_context.Nutrition_Subscriptions == null)
          {
              return NotFound();
          }
            var nutrition_Subscription = await _context.Nutrition_Subscriptions.FindAsync(id);

            if (nutrition_Subscription == null)
            {
                return NotFound();
            }

            return nutrition_Subscription;
        }

        // PUT: api/NSub/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNutrition_Subscription(int id, Nutrition_Subscription nutrition_Subscription)
        {
            if (id != nutrition_Subscription.id)
            {
                return BadRequest();
            }

            _context.Entry(nutrition_Subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Nutrition_SubscriptionExists(id))
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

        // POST: api/NSub
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nutrition_Subscription>> PostNutrition_Subscription(Nutrition_Subscription nutrition_Subscription)
        {
          if (_context.Nutrition_Subscriptions == null)
          {
              return Problem("Entity set 'IdentityApplicationContext.Nutrition_Subscriptions'  is null.");
          }
            _context.Nutrition_Subscriptions.Add(nutrition_Subscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNutrition_Subscription", new { id = nutrition_Subscription.id }, nutrition_Subscription);
        }

        // DELETE: api/NSub/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutrition_Subscription(int id)
        {
            if (_context.Nutrition_Subscriptions == null)
            {
                return NotFound();
            }
            var nutrition_Subscription = await _context.Nutrition_Subscriptions.FindAsync(id);
            if (nutrition_Subscription == null)
            {
                return NotFound();
            }

            _context.Nutrition_Subscriptions.Remove(nutrition_Subscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Nutrition_SubscriptionExists(int id)
        {
            return (_context.Nutrition_Subscriptions?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
