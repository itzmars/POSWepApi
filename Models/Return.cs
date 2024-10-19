using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using POSWebApi.Models;

public class Return
{
    [Key]
    public int ReturnId { get; set; } // Primary Key

    // Foreign key referencing the OrderDetailId
    [ForeignKey("OrderDetail")]
    public Guid OrderDetailId { get; set; }
    
    // Navigation property for relationship with OrderDetail
    public OrderDetail OrderDetail {get; set;}

    [Required]
    public DateTime ReturnDate { get; set; } = DateTime.Now; // Default to current timestamp

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "QuantityReturned must be greater than 0")]
    public int QuantityReturned { get; set; } // Must be greater than 0

    public string Reason { get; set; } // Optional reason for return

    [Column(TypeName = "decimal(10,2)")]
    [Range(0, double.MaxValue, ErrorMessage = "RefundAmount must be greater than or equal to 0")]
    public decimal RefundAmount { get; set; } = 0.00m; // Default refund amount

    // Timestamps
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}