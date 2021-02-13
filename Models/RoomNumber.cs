using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourAgency1.Models
{
    public class RoomNumber
    {
        [Key]
        [Required]
        public int Id { get; set; }
       
        [Required]
        public int roomNumber { get; set; }

        [Required]
        public bool IsReserved { get; set; }

        [Required]
        public decimal RoomSum { get; set; }

    
        public int? roomTypeId { get; set; }

        [Required]
        public int HotelId { get; set; }

        public HotelRoom hotelRoom { get; set; }

        public Hotels hotels { get; set; }

        public List<Booking> booking { get; set; }


    }
}
