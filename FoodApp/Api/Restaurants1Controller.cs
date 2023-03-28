using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodApp.Core;
using FoodApp.Data;

namespace FoodApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class Restaurants1Controller : ControllerBase
    {
        private readonly FoodAppContext _context;

        public Restaurants1Controller(FoodAppContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
          if (_context.Restaurants == null)
          {
              return NotFound();
          }
            return await _context.Restaurants.ToListAsync();
        }

        // GET: api/Restaurants1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
          if (_context.Restaurants == null)
          {
              return NotFound();
          }
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // PUT: api/Restaurants1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.ID)
            {
                return BadRequest();
            }

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: api/Restaurants1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
          if (_context.Restaurants == null)
          {
              return Problem("Entity set 'FoodAppContext.Restaurants'  is null.");
          }
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.ID }, restaurant);
        }

        // DELETE: api/Restaurants1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            if (_context.Restaurants == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantExists(int id)
        {
            return (_context.Restaurants?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
