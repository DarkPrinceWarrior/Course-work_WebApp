using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourAgency1.Models
{
    public class Booking
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BookingId { get; set; }

        public int? AirLineId { get; set; }

        [Required]
        public int Number_of_people { get; set; }
        [Required]
        public int Number_of_days { get; set; }
        [Required]
        public int Sum { get; set; }

        [Required]
        public int RoomNumberId { get; set; }

        [Required]
        public int TouristId { get; set; }

        [Required]
        public int Status { get; set; } // 1 на подтверждение и 0 на отмену 

        [Required]
        public bool IsBooked { get; set; }

        public AirLines airLines { get; set; }

        public Users users { get; set; }

        public RoomNumber roomNumber { get; set; }


    }
}
