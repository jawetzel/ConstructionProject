using System;
using System.ComponentModel.DataAnnotations;

namespace ConstructionRepo.Data
{
    public class BaseDataModel
    {
        public BaseDataModel()
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
