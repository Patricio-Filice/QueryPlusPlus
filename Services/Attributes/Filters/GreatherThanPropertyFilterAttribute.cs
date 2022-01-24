using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class GreatherThanPropertyFilterAttribute : NonNullableValuePropertyFilterAttribute
    {
        public GreatherThanPropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath) : base(firstPropertyPath, nPropertyPath)
        {
        }

        protected override Expression GetExpression(MemberExpression memberExpression, Expression entityFilterPropertyExpression)
        {
            return Expression.GreaterThan(memberExpression, entityFilterPropertyExpression);
        }
    }
}
