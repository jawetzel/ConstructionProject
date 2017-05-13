using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Orders;

namespace CoreRepo.DataAccess.Orders
{
    public class OrderRequestDataAccess
    {
        private readonly Context DbContext;
        public OrderRequestDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<OrderRequest> GetListOfAllOrderRequests()
        {
            return DbContext.OrderRequests.Where(orderReq => orderReq.IsActive).ToList();
        }

        public List<OrderRequest> GetListOfAllOrderRequestsByName(string name)
        {
            return DbContext.OrderRequests.Where(orderReq => orderReq.IsActive && orderReq.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<OrderRequest> GetListOfAllOrderRequestsByEmail(string email)
        {
            return DbContext.OrderRequests.Where(orderReq => orderReq.IsActive && orderReq.Email.ToLower().Contains(email.ToLower())).ToList();
        }

        public List<OrderRequest> GetListOfAllOrderRequestsByPhone(string phone)
        {
            return DbContext.OrderRequests.Where(orderReq => orderReq.IsActive && orderReq.PhoneNumber.ToLower().Contains(phone.ToLower())).ToList();
        }

        public List<OrderRequest> GetListOfAllOrderRequestsByStreetAddress(string address)
        {
            return DbContext.OrderRequests.Where(orderReq => orderReq.IsActive && orderReq.AddressStreet.ToLower().Contains(address.ToLower())).ToList();
        }

        public List<OrderRequest> GetListOfAllOrderRequestsWhereCalled()
        {
            return DbContext.OrderRequests.Where(orderReq => orderReq.IsActive && orderReq.Called).ToList();
        }

        public List<OrderRequest> GetListOfAllOrderRequestsWhereNotCalled()
        {
            return DbContext.OrderRequests.Where(orderReq => orderReq.IsActive && !orderReq.Called).ToList();
        }

        public OrderRequest GetOrderRequestById(int id)
        {
            try
            {
                return DbContext.OrderRequests.First(orderReq => orderReq.IsActive && orderReq.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public OrderRequest UpdateOrderRequest(OrderRequest orderReq)
        {
            try
            {
                orderReq.LastEditedDateTime = DateTime.UtcNow;
                DbContext.OrderRequests.Update(orderReq);
                DbContext.SaveChanges();
                return orderReq;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool DeleteOrderRequest(OrderRequest orderReq)
        {
            try
            {
                orderReq.LastEditedDateTime = DateTime.UtcNow;
                orderReq.IsActive = false;
                DbContext.OrderRequests.Update(orderReq);
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
