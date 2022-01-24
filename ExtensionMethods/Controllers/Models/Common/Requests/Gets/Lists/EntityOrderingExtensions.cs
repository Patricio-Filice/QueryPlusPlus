using System.Linq.Expressions;
using QueryPlusPlus.Services.Constants;
using QueryPlusPlus.Services.Models.Common.Requests.Gets.Lists;

namespace QueryPlusPlus.ExtensionMethods.Controllers.Models.Common.Requests.Gets.Lists
{
    public static class EntityOrderingExtensions
    {
        public static OrderCriteria<TEntity> GetOrderCriteria<TEntity>(this IEntityOrderer<TEntity> entityOrdering)
        {
            var entityType = typeof(TEntity);
            var parameterExpression = Expression.Parameter(entityType, entityType.Name);

            var sortPath = entityOrdering.SortBy
                                         .Split(EntityOrdererConstants.Delimiter);

            var propertyExpression = Expression.Property(parameterExpression, sortPath[0]);
            foreach (var propertyPath in sortPath[1..])
            {
                propertyExpression = Expression.Property(propertyExpression, propertyPath);
            }             

            var objectPropertyExpression = Expression.Convert(propertyExpression, typeof(object));
            var sortByExpression = Expression.Lambda<Func<TEntity, object>>(objectPropertyExpression, parameterExpression);
            return new OrderCriteria<TEntity>(sortByExpression, entityOrdering.SortDirection);
        }
    }
}
