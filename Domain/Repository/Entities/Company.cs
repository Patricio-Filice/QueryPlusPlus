using System.ComponentModel.DataAnnotations;

namespace QueryPlusPlus.Domain.Repository.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
