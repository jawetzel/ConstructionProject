using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Account;

namespace CoreRepo.DataAccess.Account
{
    public class RoleDataAccess
    {
        private readonly Context DbContext;
        public RoleDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<Role> GetListOfAllRoles()
        {
            return DbContext.Roles.Where(role => role.IsActive).ToList();
        }

        public Role GetRoleById(int id)
        {
            try
            {
                return DbContext.Roles.First(role => role.IsActive && role.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Role GetRoleByDescription(string Descript)
        {
            try
            {
                return DbContext.Roles.First(role => role.IsActive && role.Description.Equals(Descript));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Role EditRole(Role role)
        {
            try
            {
                role.LastEditedDateTime = DateTime.UtcNow;
                DbContext.Roles.Update(role);
                DbContext.SaveChanges();
                return role;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool DeleteRole(Role role)
        {
            try
            {
                role.LastEditedDateTime = DateTime.UtcNow;
                role.IsActive = false;
                DbContext.Roles.Update(role);
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
