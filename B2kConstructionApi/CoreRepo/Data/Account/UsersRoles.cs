using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreRepo.Data.Account
{
    public class UsersRoles : BaseData
    {
        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
