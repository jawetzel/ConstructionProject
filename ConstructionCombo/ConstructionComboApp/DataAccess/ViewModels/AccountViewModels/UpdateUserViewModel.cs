using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionComboApp.DataAccess.ViewModels.AccountViewModels
{
    public class UpdateUserViewModel : BaseViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UpdatedPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}
