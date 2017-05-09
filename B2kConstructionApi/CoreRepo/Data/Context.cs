using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Data.Account;
using CoreRepo.Data.Orders;
using CoreRepo.Data.Work;
using CoreRepo.Data.Work.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CoreRepo.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        // Account
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }

        // Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRequest> OrderRequests { get; set; }

        // Work
        public DbSet<WorkSession> WorkSessions { get; set; }
        public DbSet<WorkImage> WorkImages { get; set; }
        public DbSet<ImageType> ImageTypes { get; set; }
        // Expenses
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
    }
}
