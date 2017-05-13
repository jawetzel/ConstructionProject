using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Orders;

namespace CoreRepo.DataAccess.Orders
{//begin namespace

    public class OrderDataAccess
    {//begin class

        private readonly Context DbContext;
        public OrderDataAccess(Context dbContext)
        {//begin method
            DbContext = dbContext;
        }//end method

        public List<Order> GetListOfAllOrders()
        {//begin method
            return DbContext.Orders.Where(order => order.IsActive).ToList();
        }//end method

        public List<Order> GetListOfAllOrdersAppointmentNeeded()
        {//begin method
            return DbContext.Orders.Where(order => order.IsActive && order.IsAppointmentNeeded).ToList();
        }//end method

        public List<Order> GetListOfAllOrdersComleted()
        {//begin method
            return DbContext.Orders.Where(order => order.IsActive && order.IsCompleted).ToList();
        }//end method

        public List<Order> GetListOfAllOrdersByCustomerId(int id)
        {//begin method
            return DbContext.Orders.Where(order => order.IsActive && order.UserId == id).ToList();
        }//end method

        public List<Order> GetListOfAllOrdersByCustomerName(string name)
        {//begin method
            return DbContext.Orders.Where(order => order.IsActive && order.User.Name.ToLower().Contains(name.ToLower())).ToList();
        }//end method

        public Order GetListOfAllOrdersByOrderRequestId(int id)
        {//begin method
            try
            {//begin try
                return DbContext.Orders.First(order => order.IsActive && order.OrderRequestId == id);
            }//end try
            catch (Exception e)
            {//begin catch
                Console.WriteLine(e);
                return null;
            }//end catch
        }//end method

        public Order GetOrderById(int id)
        {//begin method
            try
            {//begin try
                return DbContext.Orders.First(order => order.IsActive && order.Id == id);
            }//end try
            catch (Exception e)
            {//begin catch
                Console.WriteLine(e);
                return null;
            }//end catch
        }//end method

        public Order UpdateOrder(Order order)
        {//begin method
            try
            {//begin try
                order.LastEditedDateTime = DateTime.UtcNow;
                DbContext.Orders.Update(order);
                DbContext.SaveChanges();
                return order;
            }//end try
            catch (Exception e)
            {//begin catch
                Console.WriteLine(e);
                return null;
            }//end catch
        }//end catch

        public bool DeleteOrder(Order order)
        {//begin method
            try
            {//begin try
                order.LastEditedDateTime = DateTime.UtcNow;
                order.IsActive = false;
                DbContext.Orders.Update(order);
                DbContext.SaveChanges();
                return true;
            }//end try
            catch (Exception e)
            {//begin catch
                Console.WriteLine(e);
                return false;
            }//end catch
        }//end method

        public bool CreateOrder(OrderRequest newOrderRequest)
        {//begin method
            try
            {//begin try
                var newOrder = new Order();
                DbContext.Orders.Add(newOrder);
                DbContext.SaveChanges();
                return true;
            }//end try
            catch (Exception e)
            {//begin catch
                Console.WriteLine(e);
                return false;
            }//end try
        }//end method

    }//end class

}//end namespace
