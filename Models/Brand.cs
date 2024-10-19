using System.ComponentModel.DataAnnotations;

namespace POSWebApi.Models
{
    public class Brand
    {
        [Key]
        public Guid BrandId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string BrandName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}