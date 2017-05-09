using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreRepo.Data.Account
{
    public class Session : BaseData
    {
        public string Token { get; set; }
        public DateTime ExpireDateTime { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
