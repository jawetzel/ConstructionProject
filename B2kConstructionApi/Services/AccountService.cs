using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Data.Account;
using CoreRepo.DataAccess;
using ModelsAndMaps;
using ModelsAndMaps.DataMappings;
using ModelsAndMaps.RequestModels;
using ModelsAndMaps.ResponseModels;
using Services.Functions;

namespace Services
{
    public class AccountService
    {
        public DataAccess Data;
        public AccountService(DataAccess dataAccess)
        {
            Data = dataAccess;
        }

        public LoginResViewModel Login(LoginRequestModel reqModel)
        {
            var responseModel = new LoginResViewModel();
            var foundUser = Data.UserData.GetUserByEmail(reqModel.UserName);
            if (foundUser == null)
            {
                responseModel.Success = false;
                return responseModel;
            }
            var loginUser = new User { Password = reqModel.Password, Salt = foundUser.Salt };
            loginUser = CryptoFunctions.CreateCryptoForPassword(loginUser);
            if (loginUser.Password.Equals(foundUser.Password))
            {
                var session = new Session
                {
                    User = foundUser,
                    UserId = foundUser.Id,
                    ExpireDateTime = DateTime.UtcNow.AddHours(8)
                };
                responseModel.Token = DateTime.UtcNow.ToString() + new Guid() + new Guid();
                session.Token = responseModel.Token;
                Data.SessionData.CreateSession(session);
                foreach (var role in Data.UsersRolesData.GetListOfAllUsersRolesesByUserId(foundUser.Id))
                {
                    responseModel.Roles.Add(role.Role);
                }
                responseModel.Success = true;
                return responseModel;
            }
            responseModel.Success = false;
            return responseModel;
        }

        public BaseResponseModel Register(RegisterRequestModel reqModel)
        {
            var response = new BaseResponseModel();
            if (Data.UserData.GetUserByEmail(reqModel.Email) == null)
            {
                var newUser = AccountMaps.MapRegiserRequestModelToUser(reqModel);
                newUser = CryptoFunctions.CreateCryptoForPassword(newUser);
                var saveduser = Data.UserData.CreateNewUser(newUser);
                if (saveduser != null)
                {
                    response.Success = true;
                    return response;
                }
                response.NoSuccessReason = "Failed To Create Account";
            }
            if (response.NoSuccessReason.Length <= 0)
            {
                response.NoSuccessReason = "Email Already Taken";
            }
            response.Success = false;
            return response;
        }


    }
}
