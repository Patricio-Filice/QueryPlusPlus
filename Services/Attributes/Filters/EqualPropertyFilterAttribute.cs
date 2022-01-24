using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class EqualPropertyFilterAttribute : NonNullableValuePropertyFilterAttribute
    {

        public EqualPropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath)
            : base(firstPropertyPath, nPropertyPath)
        {
        }

        protected override Expression GetExpression(MemberExpression memberExpression, Expression entityFilterPropertyExpression)
        {
            return Expression.Equal(memberExpression, entityFilterPropertyExpression);
        }
    }
}
