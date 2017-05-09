using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ConstructionRepo.Data.models.AccountModels;

namespace ConstructionRepo.Data.models.OrderModels.WorkAppointments
{
    public class AppointmentModel : BaseDataModel
    {
        public AppointmentModel()
        {
            IsNewAppointmentNeeded = false;
        }

        public DateTime? AppointmentTime { get; set; }
        public DateTime? WorkSiteArrivalTime { get; set; }
        public DateTime? WorkSiteDepartureTime { get; set; }
        public DateTime? TravelDepartureTime { get; set; }
        public DateTime? TravelArrivalTime { get; set; }

        public bool? IsEmployeeOntime { get; set; }
        public bool? IsCustomerPresent { get; set; }
        public bool? IsAppointMissed { get; set; }
        public bool IsNewAppointmentNeeded { get; set; }
        public bool? IsAppointmentKept { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public UserModel Employee { get; set; }

        [ForeignKey("WorkSession")]
        public int? WorkSessionId { get; set; }
        public WorkSessionModel WorkSession { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
