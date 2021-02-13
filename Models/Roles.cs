using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourAgency1.Models
{
    public class Roles
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string RoleName { get; set; }

        public List<Users> user { get; set; }

    }
}
