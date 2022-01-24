using System.ComponentModel.DataAnnotations;

namespace QueryPlusPlus.Domain.Repository.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public List<ProductReview> Reviews { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
