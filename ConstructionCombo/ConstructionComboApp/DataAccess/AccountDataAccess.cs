using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ConstructionComboApp.Data;
using ConstructionComboApp.Data.models.AccountModels;
using ConstructionComboApp.DataAccess.ViewModels;
using ConstructionComboApp.DataAccess.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ConstructionComboApp.DataAccess
{
    public class AccountDataAccess
    {
        private readonly DataContext _context;         //setup for DI
        public AccountDataAccess(DataContext context)   //dependency injection yo
        {
            _context = context;
        }

        public bool CheckSessionToken(string token)
        {
            try
            {
                SessionModel oldToken = GetSessionByToken(token);
                if ( oldToken.ExpireDateTime >= DateTime.Now)
                {
                    return UpdateSessionToken(oldToken);
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string CreaseSessionToken(LoginViewModel user)
        {
            var session = new SessionModel();
            session.ExpireDateTime = DateTime.Now.AddHours(8);
            session.LastEditedDateTime = DateTime.Now;
            session.CreatedDateTime = DateTime.Now;
            session.IsActive = true;
            session.Token = DateTime.Now.ToString(CultureInfo.InvariantCulture) + Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
            try
            {
                session.User = GetUserByEmail(user.UserName);
                session.UserId = session.User.Id;
                _context.Sessions.Add(session);
                _context.SaveChanges();
                return session.Token;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public bool UpdateSessionToken(SessionModel session)
        {
            try
            {
                var foundSession = GetSessionByToken(session.Token);
                foundSession.ExpireDateTime = DateTime.Now.AddHours(8);
                _context.Update(foundSession);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreateNewUser(RegisterViewModel user)
        {
            var role = GetRoleByDescription("User");
            UserModel userModel = new UserModel
            {
                Role = role,
                RoleId = role.Id,
                CreatedDateTime = DateTime.Now,
                LastEditedDateTime = DateTime.Now,
                IsActive = true,
                Email = user.Email
            };
            userModel = CreateCryptoForPassword(user.Password, userModel);
            try
            {
                _context.Users.Add(userModel);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public bool UpdateUser(UpdateUserViewModel user)
        {
            var changed = false;
            UserModel oldUser;
            try
            {
                oldUser = GetSessionByToken(user.SessionToken).User;
            }
            catch (Exception e)
            {
                return false;
            }
            if (!string.Equals(oldUser.Role.Description, user.Role) && user.Role.Length > 0)
            {
                oldUser.Role = GetRoleByDescription(user.Role);
                oldUser.RoleId = oldUser.Role.Id;
                changed = true;
            }
            if (!string.Equals(oldUser.Email, user.Email) & user.Email.Length > 0)
            {
                oldUser.Email = user.Email;
                changed = true;
            }
            if (!string.Equals(oldUser.Password, GetCrypotdPassword(user.UpdatedPassword, oldUser.Salt)) & user.UpdatedPassword.Length > 0)
            {
                oldUser.Password = GetCrypotdPassword(user.UpdatedPassword, oldUser.Salt);
                changed = true;
            }
            if (changed)
            {
                try
                {
                    _context.Update(oldUser);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;

        }

        public RoleModel GetRoleByDescription(string descr)
        {
            return _context.Roles.Single(role => role.Description == descr);
        }

        public SessionModel GetSessionByToken(string token)
        {
            return _context.Sessions.Single(session => string.Equals(session.Token, token));
        }

        public UserModel GetUserByEmail(string email)
        {
            return _context.Users.Single(user => string.Equals(user.Email, email));
        }

        public string GetCrypotdPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        public UserModel CreateCryptoForPassword(string password, UserModel user)
        {
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            user.Salt = salt;
            user.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return user;
        }

    }
}
