using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QueryPlusPlus.Controllers.Attributes.Filters
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class FilterByPropertyAttribute : Attribute
    {
        protected string FirstPropertyPath { get; }

        protected IEnumerable<string> NPropertyPath { get; }

        protected FilterByPropertyAttribute(string firstPropertyPath, params string[] nPropertyPath)
        {
            this.FirstPropertyPath = firstPropertyPath;
            this.NPropertyPath = nPropertyPath;
        }

        protected MemberExpression GetPropertyExpression(ParameterExpression parameterExpression)
        {
            var propertyExpression = Expression.Property(parameterExpression, this.FirstPropertyPath);
            foreach (var propertyPath in this.NPropertyPath)
            {
                propertyExpression = Expression.Property(propertyExpression, propertyPath);
            }
            return propertyExpression;
        }

        public abstract Expression GetExpression(ParameterExpression parameterExpression, Expression entityFilterPropertyExpression);
    }
}
