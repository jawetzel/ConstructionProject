using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data;
using ConstructionComboApp.Data.models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionComboApp.DataAccess
{
    public class OrdersDataAccess
    {
        public static OrderRequestModel SaveNewOrder(DataContext context, OrderRequestModel model)
        {
            context.Entry(model).State = EntityState.Added;
            context.SaveChanges();
            return model;
        }
    }
}
