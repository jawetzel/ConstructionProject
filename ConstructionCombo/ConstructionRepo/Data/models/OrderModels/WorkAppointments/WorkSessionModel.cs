using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ConstructionRepo.Data.models.OrderModels.WorkExpsnses;

namespace ConstructionRepo.Data.models.OrderModels.WorkAppointments
{
    public class WorkSessionModel : BaseDataModel
    {
        public int OdomoterAtStartOfDay { get; set; }
        public int OdomoterAtEndOfDay { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public OrderModel Order { get; set; }

        [ForeignKey("Appountment")]
        public int? AppountmentId { get; set; }
        public AppointmentModel Appountment { get; set; }

        public ICollection<ExpenseReportModel> ExpenseReports { get; set; }
        public ICollection<WorkSessionImageModel> WorkSessionImage { get; set; }
    }
}
