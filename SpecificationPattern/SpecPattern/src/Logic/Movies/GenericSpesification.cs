using System;
using System.Linq.Expressions;

namespace Logic.Movies
{
    public class GenericSpesification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }
        public GenericSpesification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }
}
