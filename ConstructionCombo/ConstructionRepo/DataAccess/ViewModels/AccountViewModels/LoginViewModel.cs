﻿using System.ComponentModel.DataAnnotations;

namespace ConstructionRepo.DataAccess.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
