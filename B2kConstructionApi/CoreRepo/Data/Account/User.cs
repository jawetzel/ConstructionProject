using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CoreRepo.Data.Work;

namespace CoreRepo.Data.Account
{
    public class User : BaseData
    {
        public User()
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
        public int? ZipAddress { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public byte[] Salt { get; set; }

        public ICollection<UsersRoles> UsersRoles { get; set; }

        public ICollection<WorkSession> WorkSessions { get; set; }
    }
}
