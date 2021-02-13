using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TourAgency1.Models
{
    public class AirLines
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int AirCompId { get; set; }

        [Required]
        public string AirLineName { get; set; }

        [Required]
        public int CityBoardingId { get; set; }

        [Required]
        public decimal TheSum { get; set; }

        [Required]
        public int CityLandingId { get; set; }


        public List<Booking> booking { get; set; }

        public City_From city_From { get; set; }

        public AirCompany airCompany { get; set; }

        public CityLanding cityLanding { get; set; }

    }
}
