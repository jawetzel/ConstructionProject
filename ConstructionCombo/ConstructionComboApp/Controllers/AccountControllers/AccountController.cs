using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data.models.AccountModels;
using ConstructionComboApp.DataAccess.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionComboApp.Controllers.AccountControllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        [HttpPost]
        [Route("register")]
        public JsonResult Register([FromBody] RegisterViewModel input)
        {
            return Json(new { success = true, order = input });
        }

        [HttpPost]
        [Route("login")]
        public JsonResult Login([FromBody] LoginViewModel input)
        {
            return Json(new { success = true, order = input });
        }

    }
}