using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace POSWebApi.Models
{
    public class SystemLog
    {
        [Key]
        public Guid LogId { get; set; } 

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [StringLength(255)]
        public string Action { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime LogDate { get; set; } = DateTime.Now; 
    }
}