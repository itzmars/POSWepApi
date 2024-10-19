using System;
using System.ComponentModel.DataAnnotations;

namespace POSWebApi.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime PaymentDate { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Relationships
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}