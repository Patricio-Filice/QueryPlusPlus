using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class LessThanPropertyFilterAttribute : NonNullableValuePropertyFilterAttribute
    {
        public LessThanPropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath) : base(firstPropertyPath, nPropertyPath)
        {
        }

        protected override Expression GetExpression(MemberExpression memberExpression, Expression entityFilterPropertyExpression)
        {
            return Expression.LessThan(memberExpression, entityFilterPropertyExpression);
        }
    }
}
