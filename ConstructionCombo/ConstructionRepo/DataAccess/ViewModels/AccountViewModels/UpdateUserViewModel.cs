using System.ComponentModel.DataAnnotations;

namespace ConstructionRepo.DataAccess.ViewModels.AccountViewModels
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
