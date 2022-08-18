using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Talabat.DAL.Entities;

namespace Talabat.API.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get ; set ; }
        public List<Expression<Func<T, object>>> Includes { get ; set ; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set ; }
        public int Take { get; set ; }
        public int Skip { get ; set ; }
        public bool IsPaginationEnabled { get ; set ; }

        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }
        public BaseSpecification()
        {

        }

        public void AddInclude(Expression<Func<T, object>> Include)
        {
            Includes.Add(Include);
        }

        public void AddOrderBy(Expression<Func<T, object>> orderby)
        {
            OrderBy = orderby;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> orderbyDesc)
        {
            OrderByDesc = orderbyDesc;
        }

        public void ApplyPagination (int take , int skip)
        {
            Take= take;
            Skip= skip;
            IsPaginationEnabled = true;
        }
    }
}
