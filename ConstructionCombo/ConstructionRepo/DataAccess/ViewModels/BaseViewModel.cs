using System.ComponentModel.DataAnnotations;

namespace ConstructionRepo.DataAccess.ViewModels
{
    public class BaseViewModel
    {
        [Required]
        public string SessionToken { get; set; }
    }
}
