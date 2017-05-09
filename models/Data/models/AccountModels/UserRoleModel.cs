using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionRepo.Data.models.AccountModels
{
    public class UserRoleModel : BaseDataModel
    {
        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public RoleModel Role { get; set; }

        [ForeignKey("UserRole")]
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
