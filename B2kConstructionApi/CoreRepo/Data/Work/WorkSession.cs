using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreRepo.Data.Account;
using CoreRepo.Data.Orders;

namespace CoreRepo.Data.Work
{
    public class WorkSession : BaseData
    {
        public WorkSession()
        {
            IsNewAppointmentNeeded = false;
        }
        public DateTime? AppointmentTime { get; set; }
        public DateTime? WorkSiteArrivalTime { get; set; }
        public DateTime? WorkSiteDepartureTime { get; set; }
        public DateTime? TravelArrivalTime { get; set; }
        public DateTime? TravelDepartureTime { get; set; }

        public bool? IsEmployeeOntime { get; set; }
        public bool? IsCustomerPresent { get; set; }
        public bool? IsAppointMissed { get; set; }
        public bool IsNewAppointmentNeeded { get; set; }

        public bool? IsWorkVehicle { get; set; }
        public int? OdomoterAtStartOfDay { get; set; }
        public int? OdomoterAtEndOfDay { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public User Employee { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public ICollection<WorkImage> WorkImages { get; set; }
        public ICollection<WorkSession> WorkSessions { get; set; }
    }
}
