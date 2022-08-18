using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Talabat.DAL.Entities;

namespace Talabat.API.Specifications
{
    public interface ISpecification<T> where T : BaseEntity
    {

        public Expression<Func<T , bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> OrderBy { get; set; }

        public Expression<Func<T, object>> OrderByDesc { get; set; }

        public int Take { get; set; }

        public int Skip { get; set; }

        public bool IsPaginationEnabled { get; set; }

    }
}
