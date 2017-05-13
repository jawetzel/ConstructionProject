using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Account;

namespace CoreRepo.DataAccess.Account
{
    public class UserDataAccess
    {
        private readonly Context DbContext;
        public UserDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<User> GetListOfAllUsers()
        {
            return DbContext.Users.Where(user => user.IsActive).ToList();
        }

        public List<User> GetListOfUsersByPartialStreetAddress(string address)
        {
            return DbContext.Users.Where(user => user.IsActive && user.StreetAddress.ToLower().Contains(address.ToLower())).ToList();
        }

        public User GetUserById(int id)
        {
            try
            {
                return DbContext.Users.First(user => user.IsActive && user.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public User GetUserByName(string name)
        {
            try
            {
                return DbContext.Users.First(user => user.IsActive && user.Name.Equals(name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return DbContext.Users.First(user => user.IsActive && user.Name.Equals(email));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public User EditUser(User user)
        {
            try
            {
                user.LastEditedDateTime = DateTime.UtcNow;
                DbContext.Users.Update(user);
                DbContext.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                user.LastEditedDateTime = DateTime.UtcNow;
                user.IsActive = false;
                DbContext.Users.Update(user);
                foreach (var userRole in DbContext.UsersRoles.Where(userRoles => userRoles.IsActive && userRoles.UserId == user.Id).ToList())
                {
                    userRole.IsActive = false;
                    userRole.LastEditedDateTime = DateTime.UtcNow;
                    DbContext.UsersRoles.Update(userRole);
                }
                foreach (var session in DbContext.Sessions.Where(sess => sess.IsActive && sess.UserId == user.Id).ToList())
                {
                    session.IsActive = false;
                    session.LastEditedDateTime = DateTime.UtcNow;
                    DbContext.Sessions.Update(session);
                }
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
    }
}
