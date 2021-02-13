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
    public class CityLandingsController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public CityLandingsController(TourAgencyContext context)
        {
            _context = context;
        }

        // GET: api/CityLandings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityLanding>>> GetcityLanding()
        {
            
            return await _context.cityLanding.ToListAsync();
           
        }

        // GET: api/CityLandings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityLanding>> GetCityLanding(int id)
        {
            var cityLanding = await _context.cityLanding.FindAsync(id);

            if (cityLanding == null)
            {
                return NotFound();
            }

            return cityLanding;
        }

        // PUT: api/CityLandings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityLanding(int id, CityLanding cityLanding)
        {
            if (id != cityLanding.Id)
            {
                return BadRequest();
            }

            _context.Entry(cityLanding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityLandingExists(id))
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

        // POST: api/CityLandings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityLanding>> PostCityLanding(CityLanding cityLanding)
        {
            _context.cityLanding.Add(cityLanding);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityLanding", new { id = cityLanding.Id }, cityLanding);
        }

        // DELETE: api/CityLandings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityLanding(int id)
        {
            var cityLanding = await _context.cityLanding.FindAsync(id);
            if (cityLanding == null)
            {
                return NotFound();
            }

            _context.cityLanding.Remove(cityLanding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityLandingExists(int id)
        {
            return _context.cityLanding.Any(e => e.Id == id);
        }
    }
}
