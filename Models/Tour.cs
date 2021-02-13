using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TourAgency1.Models
{
    public class Tour
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Tour_Name { get; set; }

        [Required]
        public string descrip { get; set;}

        public string Pictures { get; set; }

        public List<Hotels> Hotel { get; set; }

        

    }
}
