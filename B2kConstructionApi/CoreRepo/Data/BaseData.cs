using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreRepo.Data
{
    public class BaseData
    {
        public BaseData()
        {
            IsActive = true;
            CreatedDateTime = DateTime.Now;
            LastEditedDateTime = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastEditedDateTime { get; set; }
    }
}
