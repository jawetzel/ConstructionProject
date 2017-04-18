using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConstructionComboApp.Data
{
    public class DataContext:IdentityDbContext<UserModel, IdentityRoleModel, string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<IdentityRoleModel> IdentityRoleModels { get; set; }
        public DbSet<OrderRequestModel> OrderRequestModels { get; set; }
    }
}
