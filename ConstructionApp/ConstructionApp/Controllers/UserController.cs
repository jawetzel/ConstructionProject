using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ConstructionDatabaseRepo;
using ConstructionDatabaseRepo.dataModels;
using ConstructionDatabaseRepo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionApp.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly ConstructionRepository _repo;         //setup for DI
        public UserController(ConstructionRepository repo)   //dependency injection yo
        {
            this._repo = repo;
        }

        [HttpGet]
        [Route("getCustomers")]
        public JsonResult GetCustomers(ApiAuthViewModel model)
        {
            return Json(new { success = true });
        }

        [HttpGet]
        [Route("getEmployees")]
        public JsonResult GetEmployees(ApiAuthViewModel model)
        {
            return Json(new { success = true });
        }

        [HttpGet]
        [Route("getManagers")]
        public JsonResult GetManager(ApiAuthViewModel model)
        {
            return Json(new { success = true });
        }

        [HttpGet]
        [Route("getAdmins")]
        public JsonResult GetAdmin(ApiAuthViewModel model)
        {
            return Json(new { success = true });
        }

        [HttpGet]
        [Route("createUser")]
        public ActionResult CreateUser(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _repo.UserDataRequests.CreateNewUser(model);
                    // send email to confirm here emailAddress here
                    return Json(new { success = true, modelValid = false,  user = user });
                }
                return Json(new { success = false, modelValid = false });
            }
            catch (Exception ex)
            {
                return Json(new { success =  false, exception = ex });
            }
        }

        [HttpPost]
        [Route("updateUser")]
        public ActionResult UpdateUser(UserViewModel model)
        {
            return Json(new { success = true });    
        }

        [HttpGet]
        [Route("CreateSession")]
        public object CreateSession(string value)
        {
            return Json(new {success = true, sometimes = false});
        }
    }
}