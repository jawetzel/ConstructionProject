using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Data.Account;

namespace ModelsAndMaps.ResponseModels
{
    public class LoginResViewModel : BaseResponseModel
    {
        public LoginResViewModel()
        {
            Roles = new List<Role>();
        }
        public string Token { get; set; }
        public List<Role> Roles { get; set; }
    }
}
