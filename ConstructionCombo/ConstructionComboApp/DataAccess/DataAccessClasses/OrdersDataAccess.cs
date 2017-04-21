using System.Collections.Generic;
using System.Linq;
using ConstructionComboApp.Data;
using ConstructionComboApp.Data.models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionComboApp.DataAccess.DataAccessClasses
{
    public class OrdersDataAccess
    {
        private readonly DataContext _context;
        public OrdersDataAccess(DataContext contaxt)   //dependency injection yo
        {
            _context = contaxt;
        }

        public OrderRequestModel SaveNewOrder(OrderRequestModel model)
        {
            model.IsActive = true;
            _context.Entry(model).State = EntityState.Added;
            _context.SaveChanges();
            return model;
        }
        public List<OrderRequestModel> GetActiveOrders()
        {
            var orders = _context.OrderRequestModels.Where(order => order.IsActive).ToList();
            return orders;
        }
    }
}
