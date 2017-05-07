using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConstructionRepo.Data.models.AccountModels
{
    public class UserModel : BaseDataModel
    {
        public UserModel()
        {
            EmailVerified = false;
        }

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        [StringLength(50)]
        public string StreetAddress { get; set; }
        [StringLength(50)]
        public string CityAddress { get; set; }
        [StringLength(50)]
        public string StateAddress { get; set; }
        [StringLength(50)]
        public string ZipAddress { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public byte[] Salt { get; set; }

        public ICollection<SessionModel> Session { get; set; }
        public ICollection<UserRoleModel> UserRoles { get; set; }

    }
}
