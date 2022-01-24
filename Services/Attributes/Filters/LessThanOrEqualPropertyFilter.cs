using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class LessThanOrEqualPropertyFilter : NonNullableValuePropertyFilterAttribute
    {
        public LessThanOrEqualPropertyFilter(string firstPropertyPath, params string[] nPropertyPath)
            : base(firstPropertyPath, nPropertyPath)
        {
        }

        protected override Expression GetExpression(MemberExpression memberExpression, Expression entityFilterPropertyExpression)
        {
            return Expression.LessThanOrEqual(memberExpression, entityFilterPropertyExpression);
        }
    }
}
