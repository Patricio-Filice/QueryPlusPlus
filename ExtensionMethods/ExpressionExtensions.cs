using System.Linq.Expressions;

namespace QueryPlusPlus.ExtensionMethods
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
            => Combine(left, right, ExpressionType.AndAlso);

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
            => Combine(left, right, ExpressionType.OrElse);

        private static Expression<Func<T, bool>> Combine<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right, ExpressionType type)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.MakeBinary(
                                      type,
                                      left.Body,
                                      right.Invoke(left.Parameters[0])),
                                      left.Parameters);
        }

        public static Expression Invoke<T, TResult>(this Expression<Func<T, TResult>> source, Expression arg)
            => source.Body.ReplaceParameter(source.Parameters[0], arg);

        private static Expression ReplaceParameter(this Expression source, ParameterExpression parameter, Expression value)
            => new ParameterReplacer(parameter, value).Visit(source);

        private class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression parameter;
            private readonly Expression value;

            public ParameterReplacer(ParameterExpression parameter, Expression value)
            {
                this.parameter = parameter;
                this.value = value;
            }

            protected override Expression VisitParameter(ParameterExpression node)
                => node == this.parameter ? this.value : node;
        }
    }
}
