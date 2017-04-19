using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data.models;
using ConstructionComboApp.DataAccess.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionComboApp.Controllers.AccountControllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> loginManager;
        private readonly RoleManager<IdentityRoleModel> roleManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> loginManager, RoleManager<IdentityRoleModel> roleManager)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                UserModel user = new UserModel();
                user.UserName = obj.UserName;
                user.Email = obj.Email;

                IdentityResult result = userManager.CreateAsync
                (user, obj.Password).Result;

                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync("NormalUser").Result)
                    {
                        IdentityRoleModel role = new IdentityRoleModel();
                        role.Name = "NormalUser";
                        role.Description = "Perform normal operations.";
                        IdentityResult roleResult = roleManager.
                        CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("",
                             "Error while creating role!");
                            return Json(new { result = obj });
                        }
                    }
                    userManager.AddToRoleAsync(user,
                                 "NormalUser").Wait();
                    return Json(new { Success = true });
                }
            }
            return Json(new { result = obj });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = loginManager.PasswordSignInAsync
                (obj.UserName, obj.Password,
                  obj.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return Json(new { Success = true });
                }

                ModelState.AddModelError("", "Invalid login!");
            }

            return Json(new { result = obj });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult LogOff()
        {
            loginManager.SignOutAsync().Wait();
            return Json(new { Success = true });
        }
    }
}