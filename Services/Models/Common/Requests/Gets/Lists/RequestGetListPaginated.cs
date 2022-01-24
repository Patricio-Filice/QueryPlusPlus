using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using QueryPlusPlus.Services.Constants;

namespace QueryPlusPlus.Services.Models.Common.Requests.Gets.Lists
{
    public class RequestGetListPaginated
    {
        public RequestGetListPaginated()
        {
            this.Page = PaginationConstants.DefaultPage;
            this.PageSize = PaginationConstants.DefaultPageSize;
        }

        [DefaultValue(PaginationConstants.DefaultPage)]
        [Range(1, PaginationConstants.MaximumPage)]
        public int Page { get; set; }

        [DefaultValue(PaginationConstants.DefaultPageSize)]
        [Range(2, PaginationConstants.MaximumPageSize)]
        public int PageSize { get; set; }

        private int QuantitySkipped()
        {
            return (this.Page - 1) * this.PageSize;
        }

        public IQueryable<TEntity> GetPaginatedQueryable<TEntity>(IQueryable<TEntity> queryable)
        {
            return queryable.Skip(this.QuantitySkipped())
                            .Take(this.PageSize);
        }
    }
}
