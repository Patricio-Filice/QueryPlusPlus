using System.ComponentModel.DataAnnotations;

namespace QueryPlusPlus.Domain.Repository.Entities
{
    public class ProductReview
    {
        [Range(1, 5)]
        public int Score { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 15)]
        public int Description { get; set; }
    }
}
