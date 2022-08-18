using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications.ProductsSpecification
{
    public class ProductWithFiltersForCountSpecification: BaseSpecification<Product>
    {

        public ProductWithFiltersForCountSpecification(ProductsSpecParams productsSpecParams)
          : base(P =>
              (string.IsNullOrEmpty(productsSpecParams.Search) || P.Name.ToLower().Contains(productsSpecParams.Search)) &&
              (!productsSpecParams.BrandId.HasValue || productsSpecParams.BrandId == P.ProductBrandId) &&
              (!productsSpecParams.TypeId.HasValue || productsSpecParams.TypeId == P.ProductTypeId))
        {

        }
        }
}
