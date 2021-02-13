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
    public class AirLinesController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public AirLinesController(TourAgencyContext context)
        {
            _context = context;
        }

        // GET: api/AirLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirLines>>> GetAirLines()
        {
          
            return await _context.AirLines.ToListAsync();


        }

        // GET: api/AirLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirLines>> GetAirLines(int id)
        {
            var airLines = await _context.AirLines.FindAsync(id);

            if (airLines == null)
            {
                return NotFound();
            }

            return airLines;
        }

        // PUT: api/AirLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirLines(int id, AirLines airLines)
        {
            if (id != airLines.Id)
            {
                return BadRequest();
            }

            _context.Entry(airLines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirLinesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Updated Successfully!");
        }

        // POST: api/AirLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirLines>> PostAirLines(AirLines airLines)
        {
            _context.AirLines.Add(airLines);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAirLines", new { id = airLines.Id }, airLines);
            return new JsonResult("Added Successfully!");
        }

        // DELETE: api/AirLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirLines(int id)
        {
            var airLines = await _context.AirLines.FindAsync(id);
            if (airLines == null)
            {
                return NotFound();
            }

            _context.AirLines.Remove(airLines);
            await _context.SaveChangesAsync();

            return new JsonResult("Deleted Successfully!");
        }

        private bool AirLinesExists(int id)
        {
            return _context.AirLines.Any(e => e.Id == id);
        }
    }
}
