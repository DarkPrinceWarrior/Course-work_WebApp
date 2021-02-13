using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourAgency1.Models
{
    public class Hotels
    {
       
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public string Hotel_Name { get; set; }
       
        public decimal NightPrice { get; set; } //средняя цена за номер 
        [Required]
        public string descrip { get; set; }
      
        public int FreePlaces { get; set; }  // сколько осталось свободных номеров в отеле

        public string Pictures { get; set; }

        public Tour tours { get; set; }

        public List<RoomNumber> roomNumber { get; set; }



    }
}
