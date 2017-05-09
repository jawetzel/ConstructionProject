using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreRepo.Data.Account;
using CoreRepo.Data.Work;

namespace CoreRepo.Data.Orders
{
    public class Order : BaseData
    {
        public Order()
        {
            AmmountBilled = 0;
            AmmountPaid = 0;
            AmmountQuoted = 0;
            IsAppointmentNeeded = false;
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
        public OrderRequest OrderRequest { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<WorkSession> WorkSessions { get; set; }
    }
}
