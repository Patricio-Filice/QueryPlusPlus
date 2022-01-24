using System.ComponentModel;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QueryPlusPlus.Domain.Utils.Interfaces;
using QueryPlusPlus.ExtensionMethods;
using QueryPlusPlus.ExtensionMethods.Controllers.Models.Common.Requests.Gets.Lists;
using QueryPlusPlus.Services.Models.Common.Requests.Gets.Lists;
using QueryPlusPlus.Services.Models.Common.Responses.Gets.Lists;

namespace QueryPlusPlus.ExtensionMethods
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> orderBy, ListSortDirection sortDirection)
        {
            return sortDirection == ListSortDirection.Descending ? queryable.OrderByDescending(orderBy) : queryable.OrderBy(orderBy);
        }

        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> queryable, OrderCriteria<TEntity> orderCriteria)
        {
            return queryable.OrderBy(orderCriteria.SortBy, orderCriteria.SortDirection);
        }

        public static IOrderedQueryable<TEntity> ThenBy<TEntity, TKey>(this IOrderedQueryable<TEntity> queryable, Expression<Func<TEntity, TKey>> orderBy, ListSortDirection sortDirection)
        {
            return sortDirection == ListSortDirection.Descending ? queryable.ThenByDescending(orderBy) : queryable.ThenBy(orderBy);
        }

        public static IOrderedQueryable<TEntity> ThenBy<TEntity>(this IOrderedQueryable<TEntity> queryable, OrderCriteria<TEntity> orderCriteria)
        {
            return queryable.ThenBy(orderCriteria.SortBy, orderCriteria.SortDirection);
        }

        public static IOrderedQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> queryable, IEntityListing<TEntity> entityListing)
        {
            var restrictions = entityListing.ListRestrictions();
            var orderCriteria = entityListing.GetOrderCriteria();
            return queryable.Where(restrictions)
                            .OrderBy(orderCriteria.SortBy, orderCriteria.SortDirection);
        }

        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> queryable, IEnumerable<Expression<Func<TEntity, bool>>> restrictions)
        {
            return restrictions.Any() ? queryable.Where(restrictions.Aggregate((sr, nr) => sr.And(nr))) : queryable;
        }

        public static Task<List<TResponseGetList>> ProjectToListAsync<TEntity, TResponseGetList>(this IQueryable<TEntity> queryable, IMapper mapper)
            where TResponseGetList : class
        {
            return mapper.ProjectTo<TResponseGetList>(queryable)
                         .ToListAsync();
        }

        public static async Task<ResponseGetListPaginated<TResponseGetList>> ToPagedListAsync<TEntity, TResponseGetList>(this IQueryable<TEntity> queryable, IMapper mapper, RequestGetListPaginated requestGetListPaginated)
            where TResponseGetList : class
        {
            var pagedList = await queryable.CreateResponseGetListPaginatedAsync<TEntity, TResponseGetList>(requestGetListPaginated);
            pagedList.PageItems = (List<TResponseGetList>)mapper.Map<TEntity, TResponseGetList>(await requestGetListPaginated.GetPaginatedQueryable(queryable)
                                                                                                                             .ToListAsync());

            return pagedList;
        }

        public static async Task<ResponseGetListPaginated<TResponseGetList>> ProjectToPagedListAsync<TEntity, TResponseGetList>(this IQueryable<TEntity> queryable, IMapper mapper, RequestGetListPaginated requestGetListPaginated)
            where TResponseGetList : class
        {
            var responseGetListPaginated = await queryable.CreateResponseGetListPaginatedAsync<TEntity, TResponseGetList>(requestGetListPaginated);
            responseGetListPaginated.PageItems = await mapper.ProjectTo<TResponseGetList>(requestGetListPaginated.GetPaginatedQueryable(queryable))
                                                                                                                 .ToListAsync();

            return responseGetListPaginated;
        }

        public static ResponseGetListPaginated<TResponseGetList> ProjectToPagedList<TEntity, TResponseGetList>(this IQueryable<TEntity> queryable, IMapper mapper, RequestGetListPaginated requestGetListPaginated)
            where TResponseGetList : class
        {
            var responseGetListPaginated = queryable.CreateResponseGetListPaginated<TEntity, TResponseGetList>(requestGetListPaginated);
            responseGetListPaginated.PageItems = mapper.ProjectTo<TResponseGetList>(requestGetListPaginated.GetPaginatedQueryable(queryable))
                                                                                                           .ToList();

            return responseGetListPaginated;
        }

        public static Task<List<TEntity>> ToListAsync<TEntity>(this IQueryable<TEntity> queryable, int page, int pageSize)
        {
            return queryable.Skip(page * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
        }

        private async static Task<ResponseGetListPaginated<TResponseGetList>> CreateResponseGetListPaginatedAsync<TEntity, TResponseGetList>(this IQueryable<TEntity> queryable, RequestGetListPaginated requestGetListPaginated)
            where TResponseGetList : class
        {
            var responseGetListPaginated = new ResponseGetListPaginated<TResponseGetList>();
            await queryable.FillResponseGetListPaginatedAsync(responseGetListPaginated, requestGetListPaginated);
            return responseGetListPaginated;
        }
        private static ResponseGetListPaginated<TResponseGetList> CreateResponseGetListPaginated<TEntity, TResponseGetList>(this IQueryable<TEntity> queryable, RequestGetListPaginated requestGetListPaginated)
            where TResponseGetList : class
        {
            var responseGetListPaginated = new ResponseGetListPaginated<TResponseGetList>();
            queryable.FillResponseGetListPaginated(responseGetListPaginated, requestGetListPaginated);
            return responseGetListPaginated;
        }

        private async static Task FillResponseGetListPaginatedAsync<TEntity, TResponseGetList>(this IQueryable<TEntity> queryable, ResponseGetListPaginated<TResponseGetList> responseGetListPaginated, RequestGetListPaginated requestGetListPaginated)
            where TResponseGetList : class
        {
            queryable.FillResponseGetListPaginated(responseGetListPaginated, requestGetListPaginated, await queryable.CountAsync());
        }

        private static void FillResponseGetListPaginated<TEntity, TResponseGetList>(this IQueryable<TEntity> queryable, ResponseGetListPaginated<TResponseGetList> responseGetListPaginated, RequestGetListPaginated requestGetListPaginated)
            where TResponseGetList : class
        {
            queryable.FillResponseGetListPaginated(responseGetListPaginated, requestGetListPaginated, queryable.Count());
        }

        private static void FillResponseGetListPaginated<TEntity, TResponseGetList>(this IQueryable<TEntity> queryable, ResponseGetListPaginated<TResponseGetList> responseGetListPaginated, RequestGetListPaginated requestGetListPaginated, int totalCount)
            where TResponseGetList : class
        {
            responseGetListPaginated.TotalCount = totalCount;
            responseGetListPaginated.PageCount = ((totalCount - 1) / requestGetListPaginated.PageSize) + 1;
        }
    }
}
