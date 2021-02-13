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
    public class RoomNumbersController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public RoomNumbersController(TourAgencyContext context)
        {
            _context = context;
        }

        // GET: api/RoomNumbers
        [HttpGet("{HotelId}")]
        public async Task<ActionResult<IEnumerable<RoomNumber>>> GetroomNumber(int HotelId)
        {
            var RoomNumber = _context.roomNumber.Where(p => p.HotelId == HotelId).ToListAsync();

            return await RoomNumber;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomNumber>>> GetAllRooms()
        {
            return await _context.roomNumber.ToListAsync();
        }

        //// GET: api/RoomNumbers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<RoomNumber>> GetRoomNumber(int id)
        //{
        //    var roomNumber = await _context.roomNumber.FindAsync(id);

        //    if (roomNumber == null)
        //    {
        //        return NotFound();
        //    }

        //    return roomNumber;
        //}

        // PUT: api/RoomNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomNumber(int id, RoomNumber roomNumber)
        {
            if (id != roomNumber.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomNumberExists(id))
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

        // POST: api/RoomNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomNumber>> PostRoomNumber(RoomNumber roomNumber)
        {
            _context.roomNumber.Add(roomNumber);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRoomNumber", new { id = roomNumber.Id }, roomNumber);
            return new JsonResult("Added Successfully");
        }

        // DELETE: api/RoomNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomNumber(int id)
        {
            var roomNumber = await _context.roomNumber.FindAsync(id);
            if (roomNumber == null)
            {
                return NotFound();
            }

            _context.roomNumber.Remove(roomNumber);
            await _context.SaveChangesAsync();

            return new JsonResult("Deleted Successfully");
        }

        private bool RoomNumberExists(int id)
        {
            return _context.roomNumber.Any(e => e.Id == id);
        }
    }
}
