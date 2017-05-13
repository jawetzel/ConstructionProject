using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Work.Expenses;

namespace CoreRepo.DataAccess.Work.Expenses
{
    public class ExpenseTypeDataAccess
    {
        private readonly Context DbContext;
        public ExpenseTypeDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<ExpenseType> GetListOfAllExpenseTypes()
        {
            return DbContext.ExpenseTypes.Where(type => type.IsActive).ToList();
        }

        public ExpenseType GetExpenseTypesByDescription(string description)
        {
            try
            {
                return DbContext.ExpenseTypes.First(type => type.IsActive && type.Description.ToLower().Contains(description.ToLower()));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ExpenseType GetExpenseTypesById(int id)
        {
            try
            {
                return DbContext.ExpenseTypes.First(type => type.IsActive && type.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ExpenseType UpdateExpenseType(ExpenseType expenseType)
        {
            try
            {
                expenseType.LastEditedDateTime = DateTime.UtcNow;
                DbContext.ExpenseTypes.Update(expenseType);
                DbContext.SaveChanges();
                return expenseType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ExpenseType DeleteExpenseType(ExpenseType expenseType)
        {
            try
            {
                expenseType.LastEditedDateTime = DateTime.UtcNow;
                expenseType.IsActive = false;
                DbContext.ExpenseTypes.Update(expenseType);
                DbContext.SaveChanges();
                return expenseType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
