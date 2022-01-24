using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    public class EnumerableContainsPropertyFilterAttribute : FilterByPropertyAttribute
    {
        private readonly string containsMethodName;
        private readonly Type enumerableElementType;

        public EnumerableContainsPropertyFilterAttribute(Type enumerableElementType, string firstPropertyPath, params string[] nPropertyPath)
            : base(firstPropertyPath, nPropertyPath)
        {
            this.enumerableElementType = enumerableElementType;
            this.containsMethodName = "Contains";
        }

        public override Expression GetExpression(ParameterExpression parameterExpression, Expression entityFilterPropertyExpression)
        {
            var propertyExpression = this.GetPropertyExpression(parameterExpression);
            var containsMethodInfo = typeof(Enumerable).GetMethods()
                                                       .Single(mi => mi.Name == this.containsMethodName && mi.GetParameters().Length == 2)
                                                       .MakeGenericMethod(this.enumerableElementType);
            return Expression.Call(null, containsMethodInfo, entityFilterPropertyExpression, propertyExpression);
        }
    }
}
