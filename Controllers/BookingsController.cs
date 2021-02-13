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
    public class BookingsController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public BookingsController(TourAgencyContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet("{TouristId}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking(int TouristId)
        {
            var BookedTours = _context.Booking.Where(p => p.TouristId == TouristId).ToListAsync();

            return await BookedTours;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllBookings()
        {
            return await _context.Booking.ToListAsync();
        }



        //// GET: api/Bookings/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Booking>> GetBooking(int id)
        //{
        //    var booking = await _context.Booking.FindAsync(id);

        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    return booking;
        //}

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutBooking(int Id, Booking booking)
        {
            if (Id != booking.Id)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Id))
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

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingExists(booking.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
            return new JsonResult("Added Successfully");
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = _context.Booking.Where(p=>p.Id==id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(booking.First());
            await _context.SaveChangesAsync();

            return new JsonResult("Deleted Successfully");
        }

        private bool BookingExists(int Id)
        {
            return _context.Booking.Any(e => e.Id == Id);
        }
    }
}
