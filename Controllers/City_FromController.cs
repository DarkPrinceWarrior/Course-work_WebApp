using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourAgency1.Models;
using TourAgency1._0.Data;

namespace TourAgency1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class City_FromController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public City_FromController(TourAgencyContext context)
        {
            _context = context;
        }

        // GET: api/City_From
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City_From>>> Getcity_From()
        {
            return await _context.city_From.ToListAsync();
        }


        

        // GET: api/City_From/5
        [HttpGet("{Departure}")]
        public async Task<ActionResult<IEnumerable<City_From>>> GetCity_From(string Departure)
        {
            var DepartureCity = _context.city_From.Where(p => p.City == Departure).ToListAsync();

            return await DepartureCity;
        }

        // PUT: api/City_From/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity_From(int id, City_From city_From)
        {
            if (id != city_From.Id)
            {
                return BadRequest();
            }

            _context.Entry(city_From).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!City_FromExists(id))
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

        // POST: api/City_From
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City_From>> PostCity_From(City_From city_From)
        {
            _context.city_From.Add(city_From);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity_From", new { id = city_From.Id }, city_From);
        }

        // DELETE: api/City_From/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity_From(int id)
        {
            var city_From = await _context.city_From.FindAsync(id);
            if (city_From == null)
            {
                return NotFound();
            }

            _context.city_From.Remove(city_From);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool City_FromExists(int id)
        {
            return _context.city_From.Any(e => e.Id == id);
        }
    }
}
