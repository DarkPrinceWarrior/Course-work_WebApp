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
    public class AirCompaniesController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public AirCompaniesController(TourAgencyContext context)
        {
            _context = context;
        }

        // GET: api/AirCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirCompany>>> GetairCompany()
        {
            return await _context.airCompany.ToListAsync();
        }

        // GET: api/AirCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirCompany>> GetAirCompany(int id)
        {
            var airCompany = await _context.airCompany.FindAsync(id);

            if (airCompany == null)
            {
                return NotFound();
            }

            return airCompany;
        }

        // PUT: api/AirCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirCompany(int id, AirCompany airCompany)
        {
            if (id != airCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(airCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirCompanyExists(id))
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

        // POST: api/AirCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirCompany>> PostAirCompany(AirCompany airCompany)
        {
            _context.airCompany.Add(airCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirCompany", new { id = airCompany.Id }, airCompany);
        }

        // DELETE: api/AirCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirCompany(int id)
        {
            var airCompany = await _context.airCompany.FindAsync(id);
            if (airCompany == null)
            {
                return NotFound();
            }

            _context.airCompany.Remove(airCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirCompanyExists(int id)
        {
            return _context.airCompany.Any(e => e.Id == id);
        }
    }
}
