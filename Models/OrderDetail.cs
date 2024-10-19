using System;
using System.ComponentModel.DataAnnotations;

namespace POSWebApi.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; } = Guid.NewGuid();

        [Required]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Relationships
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}