﻿using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.DataAccess.Account;
using CoreRepo.DataAccess.Orders;
using CoreRepo.DataAccess.Work;
using CoreRepo.DataAccess.Work.Expenses;

namespace CoreRepo.DataAccess
{
    public class DataAccess
    {
        public DataAccess(UserDataAccess userData, SessionDataAccess sessionData, UsersRolesDataAccess usersRolesData,
            RoleDataAccess roleData, OrderDataAccess orderData, OrderRequestDataAccess orderRequestData,
            WorkSessionDataAccess workSessionData, WorkImageDataAccess workImageData, ImageTypeDataAccess imageTypeData,
            ExpensesDataAccess expenseData, ExpenseTypeDataAccess expenseTypeData)
        {
            UserData = userData;
            SessionData = sessionData;
            UsersRolesData = usersRolesData;
            RoleData = roleData;
            OrderRequestData = orderRequestData;
            OrderData = orderData;
            WorkSessionData = workSessionData;
            WorkImageData = workImageData;
            ImageTypeData = imageTypeData;
            ExpenseData = expenseData;
            ExpenseTypeData = expenseTypeData;
        }

        public UserDataAccess UserData;
        public SessionDataAccess SessionData;
        public UsersRolesDataAccess UsersRolesData;
        public RoleDataAccess RoleData;

        public OrderRequestDataAccess OrderRequestData;
        public OrderDataAccess OrderData;

        public WorkSessionDataAccess WorkSessionData;
        public WorkImageDataAccess WorkImageData;
        public ImageTypeDataAccess ImageTypeData;

        public ExpensesDataAccess ExpenseData;
        public ExpenseTypeDataAccess ExpenseTypeData;
    }
}
