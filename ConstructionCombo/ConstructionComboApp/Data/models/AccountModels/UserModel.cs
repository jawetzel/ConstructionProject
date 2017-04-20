using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConstructionComboApp.Data.models.AccountModels
{
    public class UserModel : BaseDataModel
    {
        [ForeignKey("Role")]
        public int RoleId { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool VerifiedEmail { get; set; }


        public RoleModel Role { get; set; }
        public ICollection<SessionModel> Sessions { get; set; }
    }
}
