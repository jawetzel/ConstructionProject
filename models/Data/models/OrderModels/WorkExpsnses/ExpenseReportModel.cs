using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;
using ConstructionRepo.Data.models.OrderModels.WorkAppointments;


namespace ConstructionRepo.Data.models.OrderModels.WorkExpsnses
{
    public class ExpenseReportModel : BaseDataModel
    {
        public byte[] RecieptImage { get; set; }
        public bool IsCustomerMarterial { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        [ForeignKey("ExpenseType")]
        public int ExpenseTypeId { get; set; }
        public ExpenseTypeModel ExpenseType { get; set; }

        [ForeignKey("WorkSession")]
        public int WorkSessionId { get; set; }
        public WorkSessionModel WorkSession { get; set; }
    }
}
