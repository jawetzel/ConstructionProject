using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data.models;
using Microsoft.AspNetCore.Mvc;
using ConstructionComboApp.Data;
using ConstructionComboApp.DataAccess;
using ConstructionComboApp.Services;
using Microsoft.EntityFrameworkCore;

namespace ConstructionComboApp.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class OrderController : Controller
    {
        private readonly DataContext _context;         //setup for DI
        private readonly AccountDataAccess _account;
        public OrderController(DataContext context, AccountDataAccess account)   //dependency injection yo
        {
            _context = context;
            _account = account;
        }

        [HttpPost]
        [Route("newOrder")]
        public JsonResult NewOrder([FromBody] OrderRequestModel input)
        {
            input = OrdersDataAccess.SaveNewOrder(_context, input);
            TextingService.MakeTwilioCall(input);
            return Json(new { success = true, order = input });
        }
    }
}