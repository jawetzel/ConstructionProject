using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data.models;

namespace ConstructionComboApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.OrderRequestModels.Any())
            {
                return;   // DB has been seeded
            }

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
            context.SaveChanges();
        }
    }
}
