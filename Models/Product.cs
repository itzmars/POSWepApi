using System.ComponentModel.DataAnnotations;

namespace POSWebApi.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}