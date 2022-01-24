using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class NotEqualPropertyFilter : NonNullableValuePropertyFilterAttribute
    {
        public NotEqualPropertyFilter(string firstPropertyPath, params string[] nPropertyPath)
            : base(firstPropertyPath, nPropertyPath)
        {
        }

        protected override Expression GetExpression(MemberExpression memberExpression, Expression entityFilterPropertyExpression)
        {
            return Expression.NotEqual(memberExpression, entityFilterPropertyExpression);
        }
    }
}
