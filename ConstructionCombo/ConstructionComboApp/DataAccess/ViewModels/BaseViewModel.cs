using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionComboApp.DataAccess.ViewModels
{
    public class BaseViewModel
    {
        [Required]
        public string SessionToken { get; set; }
    }
}
