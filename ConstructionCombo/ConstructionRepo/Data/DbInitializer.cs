using System.Linq;
using ConstructionRepo.Data.models;
using ConstructionRepo.Data.models.AccountModels;
using ConstructionRepo.Data.models.OrderModels;
using ConstructionRepo.Data.models.OrderModels.WorkAppointments;
using ConstructionRepo.Data.models.OrderModels.WorkExpsnses;

namespace ConstructionRepo.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (!context.OrderRequests.Any())
            {
                var orders = new OrderRequestModel[]
                {
                    new OrderRequestModel
                    {

                        Name = "Joshua Wetzel",
                        Email = "jawetzel615@gmail.com",
                        PhoneNumber = "225-305-9321",
                        AddressStreet = "36014 portsmouth dr",
                        AddressCity = "Denham springs",
                        AddressZip = 70706,
                        OrderDescription = "need tile work yo",
                        Called = false
                    }
                };
                foreach (OrderRequestModel order in orders)
                {
                    context.OrderRequests.Add(order);
                }
            }

            if (!context.Roles.Any())
            {
                var roles = new RoleModel[]
                {
                    new RoleModel
                    {
                        Role = "Admin",
                    },
                    new RoleModel
                    {
                        Role = "Manager",
                    },
                    new RoleModel
                    {
                        Role = "Employee",

                    },
                    new RoleModel
                    {
                        Role = "Customer",
                    },
                    new RoleModel
                    {
                        Role = "User",
                    }
                };
                foreach (RoleModel role in roles)
                {
                    context.Roles.Add(role);
                }
            }

            if (!context.WorkSessionImageTypes.Any())
            {
                var types = new WorkSessionImageTypeModel[]
                {
                    new WorkSessionImageTypeModel
                    {
                        Description = "Before Project",
                    },
                    new WorkSessionImageTypeModel
                    {
                        Description = "Project Completed",
                    },
                    new WorkSessionImageTypeModel
                    {
                        Description = "Before Started Work Day",
                    },
                    new WorkSessionImageTypeModel
                    {
                        Description = "After Finished Work Day",
                    },
                };
                foreach (WorkSessionImageTypeModel type in types)
                {
                    context.WorkSessionImageTypes.Add(type);
                }
            }

            if (!context.ExpenseTypes.Any())
            {
                var types = new ExpenseTypeModel[]
                {
                    new ExpenseTypeModel
                    {
                        Description = "Materials"
                    },
                    new ExpenseTypeModel
                    {
                        Description = "Tools"
                    },
                    new ExpenseTypeModel
                    {
                        Description = "Travel"
                    },
                    new ExpenseTypeModel
                    {
                        Description = "Personal"
                    },
                };
                foreach (var type in types)
                {
                    context.ExpenseTypes.Add(type);
                }
            }

            context.SaveChanges();
        }
    }
}
