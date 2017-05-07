using System.Collections.Generic;
using System.Linq;
using ConstructionRepo.Data;
using ConstructionRepo.Data.models.OrderModels;
using Microsoft.EntityFrameworkCore;

namespace ConstructionRepo.DataAccess.DataAccessClasses
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
            var orders = _context.OrderRequests.Where(order => order.IsActive).ToList();
            return orders;
        }
    }
}
