using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionDatabaseRepo.dataModels.Employee
{
    public class EmployeeShift
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        
        public DateTime StartShiftDateTime { get; set; }
        public DateTime EndShiftDateTime { get; set; }
        
        public User User { get; set; }
        public ICollection<EmployeeShiftBreak> EmployeeShiftBreaks { get; set; }
        public ICollection<EmployeeExpense> EmployeeExpenses { get; set; }
    }
}
