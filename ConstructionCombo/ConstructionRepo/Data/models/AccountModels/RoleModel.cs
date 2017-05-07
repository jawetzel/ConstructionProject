using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionRepo.Data.models.AccountModels
{
    public class RoleModel : BaseDataModel
    {
        [StringLength(50)]
        public string Role { get; set; }

        public ICollection<UserRoleModel> UserRoles { get; set; }
    }
}
