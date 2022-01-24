using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class StringContainsPropertyFilterAttribute : FilterByPropertyAttribute
    {
        public StringContainsPropertyFilterAttribute(string firstPropertyPath, params string[] nPropertyPath)
            : base(firstPropertyPath, nPropertyPath)
        {
        }

        public override Expression GetExpression(ParameterExpression parameterExpression, Expression entityFilterPropertyExpression)
        {
            var propertyExpression = this.GetPropertyExpression(parameterExpression);
            var method = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
            return Expression.Call(propertyExpression, method, entityFilterPropertyExpression);
        }
    }
}
