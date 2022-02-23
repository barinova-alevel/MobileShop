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
}
