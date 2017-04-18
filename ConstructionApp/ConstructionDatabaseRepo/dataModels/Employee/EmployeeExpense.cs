using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionDatabaseRepo.dataModels.Employee
{
    public class EmployeeExpense
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("EmployeeShift")]
        public int EmployeeShiftId { get; set; }

        public DateTime StartBreakDateTime { get; set; }
        public DateTime EndBreakDateTime { get; set; }

        public EmployeeShift EmployeeShift { get; set; }
    }
}
