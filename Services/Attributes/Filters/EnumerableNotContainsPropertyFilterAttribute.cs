using System;
using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class EnumerableNotContainsPropertyFilterAttribute : EnumerableContainsPropertyFilterAttribute
    {
        public EnumerableNotContainsPropertyFilterAttribute(Type enumerableElementType, string firstPropertyPath, params string[] nPropertyPath)
            : base(enumerableElementType, firstPropertyPath, nPropertyPath)
        {
        }

        public override Expression GetExpression(ParameterExpression parameterExpression, Expression entityFilterPropertyExpression)
        {
            return Expression.Not(base.GetExpression(parameterExpression, entityFilterPropertyExpression));
        }
    }
}
