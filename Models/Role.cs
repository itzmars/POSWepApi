using System.ComponentModel.DataAnnotations;

namespace POSWebApi.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; } = string.Empty;

        // Relationships
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}