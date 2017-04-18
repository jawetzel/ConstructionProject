using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ConstructionDatabaseRepo.dataModels.Employee;
using ConstructionDatabaseRepo.dataModels.Jobs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConstructionDatabaseRepo.dataModels
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string StreetAddress { get; set; }
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string ZipAddress { get; set; }
        public string ApptNumberAddress { get; set; }

        public DateTime JoinDate { get; set; }

        public ICollection<JobQuote> JobQuotes { get; set; }
        public ICollection<JobRequest> JobRequests { get; set; }
        public ICollection<JobAppointment> JobAppointments { get; set; }
        public ICollection<EmployeeExpense> EmployeeExpenses { get; set; }
    }
}
