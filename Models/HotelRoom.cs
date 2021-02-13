using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourAgency1.Models
{
    public class HotelRoom
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string RoomType { get; set; }

        public List<RoomNumber> roomNumber { get; set; }

    }
}
