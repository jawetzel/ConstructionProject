using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreRepo.Data.Work.Expenses
{
    public class Expense : BaseData
    {
        public Expense()
        {
            Cost = 0;
            Reimbursable = true;
            Reimbursed = false;
        }

        public string Description { get; set; }
        public double Cost { get; set; }

        public bool Reimbursable { get; set; }
        public bool Reimbursed { get; set; }
        
        [ForeignKey("ExpenseType")]
        public int? ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }

        [ForeignKey("WorkImage")]
        public int? WorkImageId { get; set; }
        public WorkImage WorkImage { get; set; }

        [ForeignKey("WorkSession")]
        public int WorkSessionID { get; set; }
        public WorkSession WorkSession { get; set; }

    }
}
