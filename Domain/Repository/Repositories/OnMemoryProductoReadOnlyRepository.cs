using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Domain.Repository.Interfaces;

namespace QueryPlusPlus.Domain.Repository.Repositories
{
    public class OnMemoryProductoReadOnlyRepository : IReadOnlyRepository<Product>
    {
        public IQueryable<Product> ListAll()
        {
            var companyIdCompanyDictionary = Enumerable.Range(1, 10)
                                                       .Select(n => new Company
                                                       {
                                                           Id = n,
                                                           Name = $"Company {n}"
                                                       })
                                                       .ToDictionary(c => c.Id);

            return Enumerable.Range(1, 100)
                             .Select(n => this.GetProduct(n, companyIdCompanyDictionary))
                             .AsQueryable();
        }

        private Product GetProduct(int number, Dictionary<int, Company> companyIdCompanyDictionary)
        {
            var product = new Product
            {
                Id = number,
                Name = $"Product {number}",
                Description = $"The description of the product {number}",
                Reviews = new List<ProductReview>(),
                CompanyId = (number % 10 + 1)
            };

            product.Company = companyIdCompanyDictionary[product.CompanyId];

            if (number > 50)
            {
                var quantityOfReviews = (number % 5 + 1);
                var score = quantityOfReviews;
                product.Reviews.AddRange(Enumerable.Range(1, quantityOfReviews)
                                                   .Select(n =>
                                                   {

                                                       var productReview = new ProductReview
                                                       {
                                                           Score = score,
                                                           Product = product,
                                                           ProductId = product.Id,
                                                           Description = $"A Review for product {product.Name} scored with {score} out of 5"
                                                       };

                                                       score = Math.Max(1, score - 1);

                                                       return productReview;
                                                   }));
            }

            return product;
        }
    }
}
