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
        public string Action { get; set; } 

        public string Description { get; set; } 

        [Required]
        public DateTime LogDate { get; set; } = DateTime.Now; 
    }
}