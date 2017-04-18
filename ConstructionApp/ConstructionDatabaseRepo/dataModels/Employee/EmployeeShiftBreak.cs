using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionDatabaseRepo.dataModels.Employee
{
    public class EmployeeShiftBreak
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("EmployeeShift")]
        public int EmployeeShiftId { get; set; }

        public DateTime ExpenseDateTime { get; set; }
        public decimal ExpenseCostAmmount { get; set; }

        public EmployeeShift EmployeeShift { get; set; }
    }
}
