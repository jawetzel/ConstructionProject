
using CoreRepo.Data.Orders;
using CoreRepo.DataAccess;
using System.Collections.Generic;

namespace Services
{//begin namespace

    class OrderService
    {//begin class

        public DataAccess Data;

        public OrderService(DataAccess dataAccess)
        {//begin constructor
            Data = dataAccess;
        }//end constructor


        //ORDER CREATION
        public void CreateOrder(int orderId)
        {//begin method
            var orderRequest = Data.OrderRequestData.GetOrderRequestById(orderId);
            Data.OrderData.CreateOrder(orderRequest);
        }//end method

        public void CreateOrder(OrderRequest newOrderRequest)
        {//begin method
            Data.OrderData.CreateOrder(newOrderRequest);
        }//end method


        //ORDER EDITING
        public void UpdateOrder(int orderId)
        {//begin method
            var newOrder = Data.OrderData.GetOrderById(orderId);
            Data.OrderData.UpdateOrder(newOrder);
        }//end method

        public void UpdateOrder(Order newOrder)
        {//beging method
            Data.OrderData.UpdateOrder(newOrder);
        }//end method


        //ORDER LISTS
        public List<Order> GetListOfAllOrders()
        {//begin method
            return Data.OrderData.GetListOfAllOrders();
        }//end method

        public List<Order> GetListOfAllOrdersAppointmentNeeded()
        {//begin method
            return Data.OrderData.GetListOfAllOrdersAppointmentNeeded();
        }//end method

        public List<Order> GetListOfAllOrdersCompleted()
        {//begin method
            return Data.OrderData.GetListOfAllOrdersCompleted();
        }//end method

        public List<Order> GetListOfAllOrdersByCustomerId(int newId)
        {//begin method
            return Data.OrderData.GetListOfAllOrdersByCustomerId(newId);
        }//end method


        //INDIVIDUAL ORDERS
        public Order GetOrderByOrderRequestId(int newId)
        {//begin method
            return Data.OrderData.GetOrderByOrderRequestId(newId);
        }//end method

        public Order GetOrderById(int newId)
        {//begin method
            return Data.OrderData.GetOrderById(newId);
        }//end method


        //DELETE ORDERS
        public void DeleteOrder(int newId)
        {//begin method
            var newOrder = Data.OrderData.GetOrderById(newId);
            Data.OrderData.DeleteOrder(newOrder);
        }//end method

        public void DeleteOrder(Order newOrder)
        {//begin method
            Data.OrderData.DeleteOrder(newOrder);
        }//end method

    }//end class

}//end namespace
