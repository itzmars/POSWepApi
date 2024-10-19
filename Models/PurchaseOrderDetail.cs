using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using POSWebApi.Models;

public class PurchaseOrderDetail
{
    [Key]
    public Guid PurchaseOrderDetailId { get; set; }

    // Foreign key referencing the PurchaseOrder table
    [Required]
    public Guid PurchaseOrderId { get; set; }
    public PurchaseOrder PurchaseOrder { get; set; }

    // Foreign key referencing the Product table
    [Required]
    public Guid ProductId { get; set; }
    public Product Product {get; set;}

    // Quantity must be greater than 0
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
    public int Quantity { get; set; }

    // Unit price must be a valid decimal with two decimal places
    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal UnitPrice { get; set; }

    // TotalPrice is computed from Quantity * UnitPrice
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}