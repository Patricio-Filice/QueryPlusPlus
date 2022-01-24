using System.ComponentModel;
using System.Linq.Expressions;

namespace QueryPlusPlus.Services.Models.Common.Requests.Gets.Lists
{
    public class OrderCriteria<TEntity>
    {
        public OrderCriteria(Expression<Func<TEntity, object>> sortBy, ListSortDirection sortDirection)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
        }

        public Expression<Func<TEntity, object>> SortBy { get; }

        public ListSortDirection SortDirection { get; }
    }
}
