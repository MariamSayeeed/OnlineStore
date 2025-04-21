using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance
{
    public class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity , TKey>(IQueryable<TEntity> inputQuery,ISpecifications<TEntity,TKey> specifications)
            where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;
            if (specifications.Criteria is not null)
            {
              query = query.Where(specifications.Criteria);
            }
            //specifications.

            query = specifications.IncludeExpressions.Aggregate(query,
                (currentQuery,
                includeExpression) => currentQuery.Include(includeExpression));

            return query;

        }
    }
}
