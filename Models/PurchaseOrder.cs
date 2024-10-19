using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POSWebApi.Models
{
    public class PurchaseOrder
    {
        [Key]
        public Guid PurchaseOrderId { get; set; } = Guid.NewGuid();
        [Required]
        public DateTime OrderDate { get; set; }

        // Relationships
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = new Supplier();
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();
    }
}
