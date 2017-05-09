using System.Linq;
using CoreRepo.Data;
using CoreRepo.Data.Account;
using CoreRepo.Data.Work;
using CoreRepo.Data.Work.Expenses;
using Services.AccountServices;
using Services.Functions;

namespace Services
{
    public class DbInitializer
    {
        public static void Init(Context context)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                var roles = new Role[]
                {
                    new Role
                    {
                        Description = "User"
                    },
                    new Role
                    {
                        Description = "Admin"
                    },
                    new Role
                    {
                        Description = "Employee"
                    },
                    new Role
                    {
                        Description = "Customer"
                    },
                    new Role
                    {
                        Description = "Manager"
                    }
                };
                foreach (var role in roles)
                {
                    context.Roles.Add(role);
                }
                context.SaveChanges();
            }

            if (!context.ImageTypes.Any())
            {
                var types = new ImageType[]
                {
                    new ImageType
                    {
                        Description = "Site Arrival",
                        IsReciept = false,
                        IsSignature = false
                    },
                    new ImageType
                    {
                        Description = "Site Departure",
                        IsReciept = false,
                        IsSignature = false
                    },
                    new ImageType
                    {
                        Description = "Job Start",
                        IsReciept = false,
                        IsSignature = false
                    },
                    new ImageType
                    {
                        Description = "Job Finish",
                        IsReciept = false,
                        IsSignature = false
                    },
                    new ImageType
                    {
                        Description = "Customer Signature",
                        IsReciept = false,
                        IsSignature = true
                    },
                    new ImageType
                    {
                        Description = "Employee Signature",
                        IsReciept = false,
                        IsSignature = true
                    },
                    new ImageType
                    {
                        Description = "Reciept",
                        IsReciept = true,
                        IsSignature = false
                    }
                };
                foreach (var type in types)
                {
                    context.ImageTypes.Add(type);
                }
                context.SaveChanges();
            }

            if (!context.ExpenseTypes.Any())
            {
                var types = new ExpenseType[]
                {
                    new ExpenseType
                    {
                        Description = "Travel"
                    },
                    new ExpenseType
                    {
                        Description = "Personal"
                    },
                    new ExpenseType
                    {
                        Description = "Tools"
                    },
                    new ExpenseType
                    {
                        Description = "Materials"
                    }
                };
                foreach (var type in types)
                {
                    context.ExpenseTypes.Add(type);
                }
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User
                    {
                        Name = "Joshua Wetzel",
                        Email = "jawetzel615@gmail.com",
                        EmailVerified = true,
                        StreetAddress = "17603 Tangi Lake Dr, Attp B",
                        CityAddress = "Hammond",
                        StateAddress = "Louisiana",
                        ZipAddress = 70403,
                        Password = "icewater"
                    },
                    new User
                    {
                        Name = "Mike Hutto",
                        Email = "mikeMikerson@gmail.com",
                        EmailVerified = true,
                        StreetAddress = "17603 Tangi Lake Dr, Attp B",
                        CityAddress = "Hammond",
                        StateAddress = "Louisiana",
                        ZipAddress = 70403,
                        Password = "mike"
                    }
                };
                foreach (var user in users)
                {
                    context.Users.Add(CryptoFunctions.CreateCryptoForPassword(user));
                }
                context.SaveChanges();
            }

            if (!context.UsersRoles.Any())
            {
                var rolesList = context.Roles.Where(role => role.Description.Equals("User") || role.Description.Equals("Admin") || role.Description.Equals("Manager")).ToList();
                var usersList = context.Users.Where(user => user.IsActive).ToList();

                foreach (var user in usersList)
                {
                    foreach (var role in rolesList)
                    {
                        context.UsersRoles.Add(new UsersRoles
                        {
                            User = user,
                            UserId = user.Id,
                            Role = role,
                            RoleId = role.Id
                        });
                    }
                }
                context.SaveChanges();
            }

        }
    }
}
