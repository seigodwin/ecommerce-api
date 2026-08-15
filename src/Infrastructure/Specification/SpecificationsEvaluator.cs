using Application.Common.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Specification
{
    public static class SpecificationsEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, BaseSpecification<T> spec)
        {
            var query = inputQuery;

            // Apply filtering (WHERE)
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            // Apply includes (INCLUDE)
            if (spec.Includes != null && spec.Includes.Any())
            {
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            // Apply ordering
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            // Apply descending ordering
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            // Apply paging
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            // Apply AsNoTracking if requested
            if (spec.AsNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }
    }
}
