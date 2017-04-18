using System;
using System.Collections.Generic;
using System.Text;
using ConstructionDatabaseRepo.dataModels;
using ConstructionDatabaseRepo.dataModels.Employee;
using ConstructionDatabaseRepo.dataModels.Jobs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
//namespace ConstructionDatabaseRepo.dataModels

namespace ConstructionDatabaseRepo.dataModels

{
    public class Data
    {
        public class ConstructionContext : IdentityDbContext<User, Role, string>
        {
            public ConstructionContext(DbContextOptions<ConstructionContext> options) : base(options)
            {
            }

            public DbSet<EmployeeExpense> EmployeeExpenses { get; set; }
            public DbSet<EmployeeShift> EmployeeShifts { get; set; }
            public DbSet<EmployeeShiftBreak> EmployeeShiftBreaks { get; set; }
            public DbSet<JobAppointment> JobAppointments { get; set; }
            public DbSet<JobQuote> JobQuotes { get; set; }
            public DbSet<JobRequest> JobRequests { get; set; }
        }
    }
}
