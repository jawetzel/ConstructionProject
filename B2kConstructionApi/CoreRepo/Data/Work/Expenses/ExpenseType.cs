using System;
using System.Collections.Generic;
using System.Text;

namespace CoreRepo.Data.Work.Expenses
{
    public class ExpenseType : BaseData
    {
        public string Description { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}
