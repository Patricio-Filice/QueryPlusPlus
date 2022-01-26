using System.ComponentModel;
using QueryPlusPlus.Controllers.Attributes.Filters;
using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Services.Models.Common.Requests.Gets.Lists;

namespace QueryPlusPlus.Services.Models.Requests.Gets.Lists
{
    public class RequestGetListProductWithQueryPlusPlus : RequestGetListPaginated, IEntityListing<Product>
    {
        public RequestGetListProductWithQueryPlusPlus()
        {
            this.SortBy = nameof(Product.Name);
        }

        [EnumerableIntContainsPropertyFilter(nameof(Product.Id))]
        public int[] Ids { get; set; }

        [EnumerableIntNotContainsPropertyFilter(nameof(Product.Id))]
        public int[] ExcludeIds { get; set; }

        [StringContainsPropertyFilter(nameof(Product.Name))]
        public string Name { get; set; }

        [StringContainsPropertyFilter(nameof(Product.Description))]
        public string Description { get; set; }

        [EnumerableIntContainsPropertyFilter(nameof(Product.CompanyId))]
        public int[] CompanyIds { get; set; }

        [EnumerableIntNotContainsPropertyFilter(nameof(Product.CompanyId))]
        public int[] ExcludeCompanyIds { get; set; }

        [StringContainsPropertyFilter(nameof(Product.Company), nameof(Product.Company.Name))]
        public string CompanyName { get; set; }

        //Adhered to business logic
        public bool HotSell { get; set; }

        [DefaultValue(nameof(Product.Name))]
        public string SortBy { get; set; }

        public ListSortDirection SortDirection { get; set; }
    }
}
