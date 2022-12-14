using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Interfaces
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {

        Task<T> GetAsync(int id);
       
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);

        Task<int> GetCountAsync(ISpecification<T> spec);    
    }
}
