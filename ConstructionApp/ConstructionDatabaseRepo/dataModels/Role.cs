using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConstructionDatabaseRepo.dataModels
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
