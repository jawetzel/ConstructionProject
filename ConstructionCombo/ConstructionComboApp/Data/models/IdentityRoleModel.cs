using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConstructionComboApp.Data.models
{
    public class IdentityRoleModel: IdentityRole
    {
        public string Description { get; set; }
    }
}
