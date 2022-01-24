using System.Linq.Expressions;
using QueryPlusPlus.Controllers.Attributes.Filters;
using QueryPlusPlus.Services.Models.Common.Requests.Gets.Lists;

namespace QueryPlusPlus.ExtensionMethods.Controllers.Models.Common.Requests.Gets.Lists
{
    public static class EntityFilterExtensions
    {
        public static List<Expression<Func<TEntity, bool>>> ListRestrictions<TEntity>(this IEntityFilter<TEntity> entityFilter)
        {
            var entityFilterType = entityFilter.GetType();            
            var propertiesInfo = entityFilterType.GetProperties()
                                                 .Where(pi => pi.GetValue(entityFilter) != null 
                                                              && pi.CustomAttributes.Any(ca => ca.AttributeType
                                                                                                 .IsSubclassOf(typeof(FilterByPropertyAttribute))));

            var expressions = Enumerable.Empty<Expression<Func<TEntity, bool>>>();
            if (propertiesInfo.Any())
            {
                var entityType = typeof(TEntity);
                var parameterExpression = Expression.Parameter(entityType, entityType.Name);
                var constantExpression = Expression.Constant(entityFilter);
                expressions = propertiesInfo.Select(pi =>
                {
                    var filterByPropertyAttribute = Attribute.GetCustomAttribute(pi, typeof(FilterByPropertyAttribute)) as FilterByPropertyAttribute;
                    var propertyExpression = Expression.Property(constantExpression, pi);
                    var expression = filterByPropertyAttribute.GetExpression(parameterExpression, propertyExpression);
                    return Expression.Lambda<Func<TEntity, bool>>(expression, parameterExpression);
                });
            }

            return expressions.ToList();
        }
    }
}
