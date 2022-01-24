using System.ComponentModel;
using System.Linq.Expressions;
using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Services.Models.Common.Requests.Gets.Lists;

namespace QueryPlusPlus.Services.Models.Requests.Gets.Lists
{
    public class RequestGetListProductWithoutQueryPlusPlus : RequestGetListPaginated
    {
        public RequestGetListProductWithoutQueryPlusPlus()
        {
            this.SortBy = nameof(Product.Name);
        }

        public int[] Ids { get; set; }

        public int[] ExcludeIds { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int[] CompanyIds { get; set; }

        public int[] ExcludeCompanyIds { get; set; }

        public string CompanyName { get; set; }

        [DefaultValue(nameof(Product.Name))]
        public string SortBy { get; set; }

        public ListSortDirection SortDirection { get; set; }

        public Expression<Func<Product, object>> GetOrderByExpression()
        {
            return this.SortBy switch
            {
                "Name" => p => p.Name,
                "Description" => p => p.Description,
                "Company.Name" => p => p.Company.Name,
                _ => throw new InvalidOperationException()
            };
        }
    }
}
