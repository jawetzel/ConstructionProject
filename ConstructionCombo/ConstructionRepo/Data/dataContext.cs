using ConstructionRepo.Data.models;
using ConstructionRepo.Data.models.AccountModels;
using ConstructionRepo.Data.models.OrderModels;
using ConstructionRepo.Data.models.OrderModels.WorkAppointments;
using ConstructionRepo.Data.models.OrderModels.WorkExpsnses;
using Microsoft.EntityFrameworkCore;

namespace ConstructionRepo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        // UserModels
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<SessionModel> Sessions { get; set; }

        // OrderModels
        public DbSet<OrderRequestModel> OrderRequests { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        // Work Sessions
        public DbSet<WorkSessionModel> WorkSessions { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }
        public DbSet<WorkSessionImageModel> WorkSessionImages { get; set; }
        public DbSet<WorkSessionImageTypeModel> WorkSessionImageTypes { get; set; }

        // Expenses
        public DbSet<ExpenseReportModel> ExpenseReports { get; set; }
        public DbSet<ExpenseTypeModel> ExpenseTypes { get; set; }

    }
}
