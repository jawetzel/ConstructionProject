using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreRepo.Data.Work
{
    public class WorkImage : BaseData
    {
        public byte[] Image { get; set; }

        public string Description { get; set; }

        [ForeignKey("ImageType")]
        public int? ImageTypeId { get; set; }
        public ImageType ImageType { get; set; }

        [ForeignKey("WorkSession")]
        public int WorkSessionId { get; set; }
        public WorkSession WorkSession { get; set; }
    }
}
