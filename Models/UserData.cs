using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourAgency1.Models
{
    public class UserData
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string birth { get; set; }
        [Required]
        public int series { get; set; }
        [Required]
        public int PNumber { get; set; }

        [Required]
        public int UserId { get; set; }

        public Users users { get; set; }

        

    }
}
