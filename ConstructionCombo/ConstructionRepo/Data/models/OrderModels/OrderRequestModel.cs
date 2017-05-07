using System;
using System.ComponentModel.DataAnnotations;

namespace ConstructionRepo.Data.models.OrderModels
{
    public class OrderRequestModel : BaseDataModel
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string AddressStreet { get; set; }
        [StringLength(50)]
        public string AddressCity { get; set; }
        [StringLength(50)]
        public int AddressZip { get; set; }
        public string OrderDescription { get; set; }
        public Boolean Called { get; set; }
    }
}
