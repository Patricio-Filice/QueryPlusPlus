using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public abstract class NonNullableValuePropertyFilterAttribute : FilterByPropertyAttribute
    {
        protected NonNullableValuePropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath)
            : base(firstPropertyPath, nPropertyPath)
        {
        }

        public override Expression GetExpression(ParameterExpression parameterExpression, Expression entityFilterPropertyExpression)
        {
            var propertyExpression = this.GetPropertyExpression(parameterExpression);
            if (propertyExpression.Type != entityFilterPropertyExpression.Type)
            {
                entityFilterPropertyExpression = Expression.Convert(entityFilterPropertyExpression, propertyExpression.Type);
            }

            return this.GetExpression(propertyExpression, entityFilterPropertyExpression);
        }

        protected abstract Expression GetExpression(MemberExpression memberExpression, Expression expression);
    }
}
