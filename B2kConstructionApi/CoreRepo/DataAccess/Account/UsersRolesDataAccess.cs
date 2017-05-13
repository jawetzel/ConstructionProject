using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Account;

namespace CoreRepo.DataAccess.Account
{
    public class UsersRolesDataAccess
    {
        private readonly Context DbContext;
        public UsersRolesDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<UsersRoles> GetListOfAllUsersRoleses()
        {
            return DbContext.UsersRoles.Where(usersRoles => usersRoles.IsActive).ToList();
        }

        public List<UsersRoles> GetListOfAllUsersRolesesByUserId(int userId)
        {
            return DbContext.UsersRoles.Where(usersRoles => usersRoles.IsActive && usersRoles.UserId == userId).ToList();
        }

        public List<UsersRoles> GetListOfAllUsersRolesesByUserName(string name)
        {
            return DbContext.UsersRoles.Where(usersRoles => usersRoles.IsActive && usersRoles.User.Name == name).ToList();
        }

        public List<UsersRoles> GetListOfAllUsersRolesesByUserEmail(string email)
        {
            return DbContext.UsersRoles.Where(usersRoles => usersRoles.IsActive && usersRoles.User.Email == email).ToList();
        }

        public UsersRoles GetUsersRolesById(int id)
        {
            try
            {
                return DbContext.UsersRoles.First(usersRoles => usersRoles.Id == id && usersRoles.IsActive);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public UsersRoles EditUsersRole(UsersRoles userRole)
        {
            try
            {
                userRole.LastEditedDateTime = DateTime.UtcNow;
                DbContext.UsersRoles.Update(userRole);
                DbContext.SaveChanges();
                return userRole;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return userRole;
            }
        }

        public UsersRoles DeleteUsersRole(UsersRoles userRole)
        {
            try
            {
                userRole.LastEditedDateTime = DateTime.UtcNow;
                userRole.IsActive = false;
                DbContext.UsersRoles.Update(userRole);
                DbContext.SaveChanges();
                return userRole;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return userRole;
            }
        }
    }
}
