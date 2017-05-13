using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Orders;

namespace CoreRepo.DataAccess.Orders
{
    public class OrderDataAccess
    {
        private readonly Context DbContext;
        public OrderDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<Order> GetListOfAllOrders()
        {
            return DbContext.Orders.Where(order => order.IsActive).ToList();
        }

        public List<Order> GetListOfAllOrdersAppointmentNeeded()
        {
            return DbContext.Orders.Where(order => order.IsActive && order.IsAppointmentNeeded).ToList();
        }

        public List<Order> GetListOfAllOrdersComleted()
        {
            return DbContext.Orders.Where(order => order.IsActive && order.IsCompleted).ToList();
        }

        public List<Order> GetListOfAllOrdersByCustomerId(int id)
        {
            return DbContext.Orders.Where(order => order.IsActive && order.UserId == id).ToList();
        }

        public List<Order> GetListOfAllOrdersByCustomerName(string name)
        {
            return DbContext.Orders.Where(order => order.IsActive && order.User.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public Order GetListOfAllOrdersByOrderRequestId(int id)
        {
            try
            {
                return DbContext.Orders.First(order => order.IsActive && order.OrderRequestId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                return DbContext.Orders.First(order => order.IsActive && order.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Order UpdateOrder(Order order)
        {
            try
            {
                order.LastEditedDateTime = DateTime.UtcNow;
                DbContext.Orders.Update(order);
                DbContext.SaveChanges();
                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool DeleteOrder(Order order)
        {
            try
            {
                order.LastEditedDateTime = DateTime.UtcNow;
                order.IsActive = false;
                DbContext.Orders.Update(order);
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
