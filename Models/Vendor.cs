using System;
using System.ComponentModel.DataAnnotations;
using POSWebApi.Models;

public class Vendor
{
    [Key]
    public int VendorId { get; set; }

    [Required]
    [MaxLength(100)]
    public string VendorName { get; set; }

    [MaxLength(100)]
    public string ContactName { get; set; }

    [MaxLength(100)]
    [EmailAddress]
    public string ContactEmail { get; set; }

    [MaxLength(20)]
    [Phone]
    public string ContactPhone { get; set; }

    public string Address { get; set; }

    [MaxLength(50)]
    public string City { get; set; }

    [MaxLength(50)]
    public string State { get; set; }

    [MaxLength(10)]
    public string ZipCode { get; set; }

    [MaxLength(50)]
    public string Country { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

      // Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
}