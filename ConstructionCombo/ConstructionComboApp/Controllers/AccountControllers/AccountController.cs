using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data;
using ConstructionComboApp.Data.models.AccountModels;
using ConstructionComboApp.DataAccess;
using ConstructionComboApp.DataAccess.DataAccessClasses;
using ConstructionComboApp.DataAccess.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionComboApp.Controllers.AccountControllers
{
    [Produces("application/json")]
    [Route("api")]
    public class AccountController : Controller
    {
        private readonly AccountDataAccess _account;
        public AccountController(AccountDataAccess account)   //dependency injection yo
        {
            _account = account;
        }

        [HttpPost]
        [Route("register")]
        public JsonResult Register([FromBody] RegisterViewModel input)
        {
            if (_account.CreateNewUser(input))
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        [Route("login")]
        public JsonResult Login([FromBody] LoginViewModel input)
        {
            var token = _account.CreaseSessionToken(input);
            if (token.Length > 0)
            {
                return Json(new { success = true, token = token });
            }
            return Json(new { success = false });
        }

    }
}