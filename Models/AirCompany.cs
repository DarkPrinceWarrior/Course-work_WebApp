using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourAgency1.Models
{
    public class AirCompany
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string AirCompName { get; set; }

        public List<AirLines> airLines { get; set; }

    }
}
