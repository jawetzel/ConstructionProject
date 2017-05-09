using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ConstructionRepo.Data.models.AccountModels;
using ConstructionRepo.Data.models.OrderModels.WorkAppointments;

namespace ConstructionRepo.Data.models.OrderModels
{
    public class OrderModel : BaseDataModel
    {
        public OrderModel()
        {
            AmmountBilled = 0;
            AmmountPaid = 0;
            AmmountQuoted = 0;
            IsCompleted = false;
        }
        public decimal AmmountBilled { get; set; }
        public decimal AmmountPaid { get; set; }
        public decimal AmmountQuoted { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }

        public bool IsAppointmentNeeded { get; set; }
        public bool IsCompleted { get; set; }

        [ForeignKey("OrderRequest")]
        public int? OrderRequestId { get; set; }
        public OrderRequestModel OrderRequest { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserModel User { get; set; }

        public ICollection<WorkSessionModel> WorkSessions { get; set; }
        public ICollection<AppointmentModel> Appointments { get; set; }
    }
}
