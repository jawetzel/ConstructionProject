using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data;
using ConstructionComboApp.Data.models.AccountModels;
using ConstructionComboApp.DataAccess.ViewModels.AccountViewModels;

namespace ConstructionComboApp.DataAccess
{
    public class AccountDataAccess
    {
        private readonly DataContext _context;         //setup for DI
        public AccountDataAccess(DataContext context)   //dependency injection yo
        {
            _context = context;
        }
        public bool CheckSessionToken()
        {
            return true;
        }

        public string CreaseSessionToken()
        {
            return "hello";
        }

        public void UpdateSessionToken(SessionModel session)
        {
            
        }

        public void CreateNewUser(RegisterViewModel user)
        {
            
        }

        public void UpdateUser(RegisterViewModel user)
        {
            
        }
    }
}
