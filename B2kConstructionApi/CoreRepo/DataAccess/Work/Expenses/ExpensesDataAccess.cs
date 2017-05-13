using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Work.Expenses;

namespace CoreRepo.DataAccess.Work.Expenses
{
    public class ExpensesDataAccess
    {
        private readonly Context DbContext;
        public ExpensesDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<Expense> GetListOfAllExpenses()
        {
            return DbContext.Expenses.Where(exp => exp.IsActive).ToList();
        }

        public List<Expense> GetListOfExpensesByWorkSessionId(int id)
        {
            return DbContext.Expenses.Where(exp => exp.IsActive && exp.WorkImageId == id).ToList();
        }

        public Expense GetExpenseById(int id)
        {
            try
            {
                return DbContext.Expenses.First(exp => exp.IsActive && exp.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Expense UpdateExpense(Expense expense)
        {
            try
            {
                expense.LastEditedDateTime = DateTime.UtcNow;
                DbContext.Expenses.Update(expense);
                DbContext.SaveChanges();
                return expense;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Expense DeleteExpense(Expense expense)
        {
            try
            {
                expense.LastEditedDateTime = DateTime.UtcNow;
                expense.IsActive = false;
                DbContext.Expenses.Update(expense);
                DbContext.SaveChanges();
                return expense;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
