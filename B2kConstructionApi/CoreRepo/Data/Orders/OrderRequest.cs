using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreRepo.Data.Orders
{
    public class OrderRequest : BaseData
    {
        public OrderRequest()
        {
            Called = false;
        }
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
        public int? AddressZip { get; set; }
        public string OrderDescription { get; set; }
        public Boolean Called { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
