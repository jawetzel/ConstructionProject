using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data.models;
using ConstructionComboApp.Data.models.AccountModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConstructionComboApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<OrderRequestModel> OrderRequestModels { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<SessionModel> Sessions { get; set; }
        public DbSet<RoleModel> Roles { get; set; }

    }
}
