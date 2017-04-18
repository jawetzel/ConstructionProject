using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ConstructionDatabaseRepo.dataModels;
using ConstructionDatabaseRepo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDatabaseRepo.dataRequests
{
    public class UserDataRequests
    {
        private readonly Data.ConstructionContext _context;         //setup for DI
        public UserDataRequests(Data.ConstructionContext context)   //dependency injection yo
        {
            _context = context;
        }


        public User CreateNewUser(UserViewModel model)
        {
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                StreetAddress = model.StreetAddress,
                ZipAddress = model.ZipAddress,
                StateAddress = model.StateAddress,
                CityAddress = model.CityAddress,
                ApptNumberAddress = model.ApptNumberAddress,
                Email = model.Email,
                JoinDate = DateTime.UtcNow
            };
            _context.Entry(user).State = EntityState.Added;
            _context.SaveChanges();
            return user;
        }
    }
}
