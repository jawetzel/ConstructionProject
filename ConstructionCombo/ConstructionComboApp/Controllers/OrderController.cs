using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data.models;
using Microsoft.AspNetCore.Mvc;
using ConstructionComboApp.Data;
using ConstructionComboApp.DataAccess;
using ConstructionComboApp.DataAccess.DataAccessClasses;
using ConstructionComboApp.DataAccess.ViewModels;
using ConstructionComboApp.Services;
using Microsoft.EntityFrameworkCore;

namespace ConstructionComboApp.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class OrderController : Controller
    {
        private readonly AccountDataAccess _account;
        private readonly OrdersDataAccess _orders;
        public OrderController(AccountDataAccess account, OrdersDataAccess orders)   //dependency injection yo
        {
            _orders = orders;
            _account = account;
        }

        [HttpPost]
        [Route("newOrder")]
        public JsonResult NewOrder([FromBody] OrderRequestModel input)
        {
            input = _orders.SaveNewOrder(input);
            TextingService.MakeTwilioCall(input);
            return Json(new { success = true, order = input });
        }

        [HttpPost]
        [Route("getActiveOrders")]
        public JsonResult GetActiveOrders([FromBody] BaseViewModel token)
        {
            var tokenCheck = _account.CheckSessionToken(token.SessionToken);
            if (tokenCheck)
            {
                var orders = _orders.GetActiveOrders();
                return Json(new { success = true, orders = orders });

            }
            return Json(new { success = false });

        }
    }
}