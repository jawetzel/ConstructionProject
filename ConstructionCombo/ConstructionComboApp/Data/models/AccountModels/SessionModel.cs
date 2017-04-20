using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConstructionComboApp.Data.models.AccountModels
{
    public class SessionModel : BaseDataModel
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Token { get; set; }
        public DateTime ExpireDateTime { get; set; }

        public UserModel User { get; set; }
    }
}
