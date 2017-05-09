using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreRepo.Data.Account
{
    public class Role : BaseData
    {
        [StringLength(50)]
        public string Description { get; set; }

        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
