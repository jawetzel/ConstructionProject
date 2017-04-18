using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDatabaseRepo.ViewModels
{
    public class UserViewModel : ApiAuthViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string ZipAddress { get; set; }
        public string ApptNumberAddress { get; set; }
        [Required]
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
        public string Password { get; set; }
        public string AuthLevel { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
