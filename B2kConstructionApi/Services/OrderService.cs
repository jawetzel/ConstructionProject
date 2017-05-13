
using CoreRepo.Data.Orders;
using CoreRepo.DataAccess;

namespace Services
{//begin namespace

    class OrderService
    {//begin class

        public DataAccess Data;

        public OrderService(DataAccess dataAccess)
        {//begin constructor
            Data = dataAccess;
        }//end constructor

        public void CreateOrderFromOrderRequestId(int newId)
        {//begin method
            var orderRequest = Data.OrderRequestData.GetOrderRequestById(newId);
            Data.OrderData.CreateOrder(orderRequest);
        }//end method

        public void CreateOrderFromOrderRequest(OrderRequest newOrderRequest)
        {//begin method
            Data.OrderData.CreateOrder(newOrderRequest);
        }//end method












    }//end class

}//end namespace
