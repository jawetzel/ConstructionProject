using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConstructionDatabaseRepo.dataModels.Jobs
{
    public class JobAppointment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("JobRequest")]
        public int JobRequestId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("JobQuote")]
        public int? JobQuoteId { get; set; }

        public DateTime AppointmentDateTime { get; set; }
        public Boolean EmployeeShowedUp { get; set; }
        public DateTime EmployeeArrivalDateTime { get; set; }
        public Boolean CustomerAbsent { get; set; }
        public Boolean NeedsNewAppointment { get; set; }

        public JobQuote JobQuote { get; set; }
        public JobRequest JobRequest { get; set; }
        public User User { get; set; }
    }
}
