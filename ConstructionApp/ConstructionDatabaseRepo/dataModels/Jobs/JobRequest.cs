using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConstructionDatabaseRepo.dataModels.Jobs
{

    public class JobRequest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public string RequestDescription { get; set; }

        public DateTime RequestDateTime { get; set; }
        public DateTime NeededByDate { get; set; }
        public Boolean JobAddressIsUserAddress { get; set; }
        public string StreetAddress { get; set; }
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string ZipAddress { get; set; }
        public string ApptNumberAddress { get; set; }

        public User User { get; set; }

        public ICollection<JobAppointment> JobAppointments { get; set; }
        public ICollection<JobQuote> JobQuotes { get; set; }

    }
}
