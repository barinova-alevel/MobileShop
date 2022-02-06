using System.Linq.Expressions;

namespace Infrastructure
{
    public static class Specification
    {
        public static Specification<T> New<T>(Expression<Func<T, bool>> expr)
        {
            return new Specification<T>(expr);
        }
    }

    public class Specification<T>
    {
        public readonly Expression<Func<T, bool>> Expression;

        public Specification(Expression<Func<T, bool>> expr)
        {
            Expression = expr;
        }

        public static implicit operator Expression<Func<T, bool>>(Specification<T> s) => s.Expression;

        public static Specification<T> operator &(Specification<T> a, Expression<Func<T, bool>> b) 
            => new Specification<T>(a.Expression.And(b));
    }

    internal static class ExpressionsExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                    return _newValue;
                return base.Visit(node);
            }
        }
    }
}
