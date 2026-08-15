using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Common.Specifications
{
    public abstract class BaseSpecification<T>
    {

        public Expression<Func<T, bool>>? Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>>? OrderBy { get; protected set; }

        public Expression<Func<T, object>>? OrderByDescending { get; protected set; }

        public int Skip { get; protected set; }

        public int Take { get; protected set; }

        public bool IsPagingEnabled { get; protected set; }

        public bool AsNoTracking { get; protected set; }

        // 2. Constructors
        protected BaseSpecification()
        {
        }

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        // 3. Helper Methods to build the query fluently
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        protected void ApplyAsNoTracking()
        {
            AsNoTracking = true;
        }
    }
}
