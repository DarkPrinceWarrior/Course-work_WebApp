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
    public class HotelsController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public HotelsController(TourAgencyContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotels>>> GetHotels(int TourId, bool check)
        {
            if (check)
            {
                var users = _context.Hotels.Where(p => p.TourId == TourId).ToListAsync();
                return await users;
            }
            else
            {
                return await _context.Hotels.ToListAsync();
            }

           
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Hotels>>> GetAllHotels()
        //{
        //    return await _context.Hotels.ToListAsync();
        //}



        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotels>> GetHotel(int id)
        {
            var hotels = await _context.Hotels.FindAsync(id);

            if (hotels == null)
            {
                return NotFound();
            }

            return hotels;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotels(int id, Hotels hotels)
        {
            if (id != hotels.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Updated Successfully");
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotels>> PostHotels(Hotels hotels)
        {
            _context.Hotels.Add(hotels);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetHotels", new { id = hotels.Id }, hotels);
            return new JsonResult("Added Successfully");
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotels(int id)
        {
            var hotels = await _context.Hotels.FindAsync(id);
            if (hotels == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotels);
            await _context.SaveChangesAsync();
            return new JsonResult("Deleted Successfully");

            //return NoContent();
        }

        private bool HotelsExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }
    }
}
