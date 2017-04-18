using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConstructionDatabaseRepo.dataModels.Jobs
{
    public class JobQuote
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("JobRequest")]
        public int JobRequestId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime QuoteDateTime { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public bool CustomerApproved { get; set; }

        public JobRequest JobRequest { get; set; }
        public User User { get; set; }
    }
}
