using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class GreaterThanOrEqualPropertyFilterAttribute : NonNullableValuePropertyFilterAttribute
    {
        public GreaterThanOrEqualPropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath)
            : base(firstPropertyPath, nPropertyPath)
        {
        }

        protected override Expression GetExpression(MemberExpression memberExpression, Expression entityFilterPropertyExpression)
        {
            return Expression.GreaterThanOrEqual(memberExpression, entityFilterPropertyExpression);
        }
    }
}
