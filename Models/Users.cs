using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourAgency1.Models
{
    public class Users
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string email { get; set; }
        [Required] 
        public string password { get; set; }
        [Required]
        public bool status { get; set; }

        [Required]
        public int RoleId { get; set; }

        public List<Booking> booking { get; set; }

        public Roles roles { get; set; }

        public UserData userData { get; set; }
    }
}
