using CoreRepo.Data.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsAndMaps.ResponseModels
{//begin namespace

    public class OrderResViewModel : BaseResponseModel
    {//begin class

        public List<Order> Orders { get; set; }

    }//end class

}//end namespace
