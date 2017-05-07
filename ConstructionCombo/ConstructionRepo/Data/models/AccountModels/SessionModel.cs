using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionRepo.Data.models.AccountModels
{
    public class SessionModel : BaseDataModel
    {
        public string Token { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public int ValidForSecconds { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
