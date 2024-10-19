using System.ComponentModel.DataAnnotations;

namespace POSWebApi.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [MaxLength(50)]
        public string SKU { get; set; } = string.Empty;
        public string Barcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal TaxRate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        // Relationships
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public int VendorId { get; set; } 
        public Vendor Vendor { get; set; }  
        public Guid SupplierId { get; set; }

        public Inventory Inventory { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();
    }
}