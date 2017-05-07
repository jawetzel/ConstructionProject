using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;

namespace ConstructionRepo.Data.models.OrderModels.WorkAppointments
{
    public class WorkSessionImageModel : BaseDataModel
    {
        public Image RecieptImage { get; set; }

        [ForeignKey("WorkSession")]
        public int WorkSessionId { get; set; }
        public WorkSessionModel WorkSession { get; set; }

        [ForeignKey("WorkSessionImageType")]
        public int? WorkSessionImageTypeId { get; set; }
        public WorkSessionImageTypeModel WorkSessionImageType { get; set; }
    }
}
