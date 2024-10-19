using System.ComponentModel.DataAnnotations;

namespace POSWebApi.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        // Relationships
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}