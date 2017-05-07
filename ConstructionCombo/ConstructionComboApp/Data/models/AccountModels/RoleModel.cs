using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionComboApp.Data.models.AccountModels
{
    public class RoleModel : BaseDataModel
    {
        public int Rank { get; set; }
        public string Description { get; set; }
        public ICollection<UserModel> Users { get; set; }
    }
}
