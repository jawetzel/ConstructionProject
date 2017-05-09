using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionComboApp.Data
{
    public class BaseDataModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastEditedDateTime { get; set; }

    }
}
