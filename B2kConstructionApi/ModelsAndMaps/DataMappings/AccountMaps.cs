using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Data.Account;
using ModelsAndMaps.RequestModels;

namespace ModelsAndMaps.DataMappings
{
    public static class AccountMaps
    {
        public static User MapRegiserRequestModelToUser(RegisterRequestModel model)
        {
            return new User
            {
                Name = model.Name,
                Email = model.Email,
                StreetAddress = model.StreetAddress,
                CityAddress = model.CityAddress,
                StateAddress = model.StateAddress,
                ZipAddress = model.ZipAddress,
                Password = model.Password
            };
        }
    }
}
