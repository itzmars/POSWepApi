using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using POSWebApi.Models;

public class Inventory
{
    [Key]
    public Guid InventoryId { get; set; }

    [Required]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "QuantityInStock must be a non-negative value.")]
    public int QuantityInStock { get; set; } = 0;

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "ReorderLevel must be a non-negative value.")]
    public int ReorderLevel { get; set; } = 10;


    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "ReorderQuantity must be a non-negative value.")]
    public int ReorderQuantity { get; set; } = 50;


    public DateTime? LastRestockDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}