using System.Linq.Expressions;

namespace Infrastructure
{
    public class Specification<T>
    {
        private readonly Expression<Func<T, bool>> _expression;

        public Specification(Expression<Func<T, bool>> expr)
        {
            _expression = expr;
        }

        public static implicit operator Expression<Func<T, bool>>(Specification<T> s) => s._expression;

        public static Specification<T> operator &(Specification<T> a, Expression<Func<T, bool>> b)
            => new Specification<T>(a._expression.And(b));
    }
}
