using System;
using System.ComponentModel.DataAnnotations;

namespace POSWebApi.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [StringLength(20)]
        [Phone]
        public string ContactPhone { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property for the relationship
        public ICollection<Product> Products { get; set; }
    }
}