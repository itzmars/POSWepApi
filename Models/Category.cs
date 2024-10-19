using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSWebApi.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;


        [MaxLength(100)]
        public string CategoryeDescription { get; set; } = string.Empty;

        public Guid? ParentCategoryId { get; set; }

       
        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }

   
        public virtual ICollection<Category> SubCategories { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        // Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}