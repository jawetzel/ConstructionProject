using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionRepo.Data.models.OrderModels.WorkAppointments
{
    public class WorkSessionImageTypeModel
    {
        public string Description { get; set; }

        public ICollection<WorkSessionImageModel> WorkSessionImage { get; set; }
    }
}
