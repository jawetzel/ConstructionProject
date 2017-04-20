using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data.models;
using ConstructionComboApp.Data.models.AccountModels;

namespace ConstructionComboApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (!context.OrderRequestModels.Any())
            {
                var users = new OrderRequestModel[]
                {
                    new OrderRequestModel
                    {

                        Name = "Joshua Wetzel",
                        Email = "jawetzel615@gmail.com",
                        PhoneNumber = "225-305-9321",
                        AddressStreet = "36014 portsmouth dr",
                        AddressCity = "Denham springs",
                        AddressZip = "70706",
                        OrderDescription = "need tile work yo",
                        Called = false
                    }
                };
                foreach (OrderRequestModel user in users)
                {
                    context.OrderRequestModels.Add(user);
                }
            }
            if (!context.Roles.Any())
            {
                var roles = new RoleModel[]
                {
                    new RoleModel
                    {
                        Rank = 5,
                        Description = "Admin",
                        CreatedDateTime = DateTime.Now,
                        LastEditedDateTime = DateTime.Now,
                        IsActive = true

                    },
                    new RoleModel
                    {
                        Rank = 4,
                        Description = "Manager",
                        CreatedDateTime = DateTime.Now,
                        LastEditedDateTime = DateTime.Now,
                        IsActive = true
                    },
                    new RoleModel
                    {
                        Rank = 3,
                        Description = "Employee",
                        CreatedDateTime = DateTime.Now,
                        LastEditedDateTime = DateTime.Now,
                        IsActive = true
                    },
                    new RoleModel
                    {
                        Rank = 2,
                        Description = "Customer",
                        CreatedDateTime = DateTime.Now,
                        LastEditedDateTime = DateTime.Now,
                        IsActive = true
                    },
                    new RoleModel
                    {
                        Rank = 1,
                        Description = "User",
                        CreatedDateTime = DateTime.Now,
                        LastEditedDateTime = DateTime.Now,
                        IsActive = true
                    }
                };
                foreach (RoleModel role in roles)
                {
                    context.Roles.Add(role);
                }
            }
            context.SaveChanges();
        }
    }
}
