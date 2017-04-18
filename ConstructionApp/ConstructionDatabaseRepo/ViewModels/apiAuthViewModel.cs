using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConstructionDatabaseRepo.ViewModels
{
    public class ApiAuthViewModel
    {
        [Required]
        public string ApiAuthAuthToken { get; set; }
        [Required]
        public string ApiAuthEmail { get; set; }
        public bool ApiAuthSuccess { get; set; }
    }
}
