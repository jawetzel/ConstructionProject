using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDatabaseRepo.dataModels
{
    public class DbInitializer
    {
        public static void Initialize(Data.ConstructionContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User
                {
                    FirstName = "Joshua",
                    LastName = "Wetzel",
                    PhoneNumber = "2253059321",
                    StreetAddress = "36014 portsmouth dr",
                    CityAddress = "Denham Springs",
                    StateAddress = "LA",
                    ZipAddress = "70706",
                    ApptNumberAddress = "",
                    Email = "jawetzel615@gmail.com",
                    JoinDate = DateTime.Now

                },
                new User
                {
                    FirstName = "Zachary",
                    LastName = "Burke",
                    PhoneNumber = "2253059321",
                    StreetAddress = "36014 portsmouth dr",
                    CityAddress = "Denham Springs",
                    StateAddress = "LA",
                    ZipAddress = "70706",
                    ApptNumberAddress = "",
                    Email = "jburke@gmail.com",
                    JoinDate = DateTime.Now

                }
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
