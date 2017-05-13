
using CoreRepo.DataAccess.Account;
using CoreRepo.DataAccess.Orders;
using CoreRepo.DataAccess.Work;
using CoreRepo.DataAccess.Work.Expenses;

namespace CoreRepo.DataAccess
{//begin namespace

    public class DataAccess
    {//begin class

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

        public DataAccess(UserDataAccess userData, SessionDataAccess sessionData, UsersRolesDataAccess usersRolesData,
                RoleDataAccess roleData, OrderDataAccess orderData, OrderRequestDataAccess orderRequestData,
                WorkSessionDataAccess workSessionData, WorkImageDataAccess workImageData, ImageTypeDataAccess imageTypeData,
                ExpensesDataAccess expenseData, ExpenseTypeDataAccess expenseTypeData)
        {//begin constructor
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
        }//end constructor

    }//end clas

}//end namespace
