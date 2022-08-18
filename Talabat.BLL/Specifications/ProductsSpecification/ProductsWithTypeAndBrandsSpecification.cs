using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Specifications;
using Talabat.BLL.Specifications.ProductsSpecification;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrandsSpecification(ProductsSpecParams productsSpecParams)
           : base(P =>
                (string.IsNullOrEmpty(productsSpecParams.Search) || P.Name.ToLower().Contains(productsSpecParams.Search)) &&
                (!productsSpecParams.BrandId.HasValue || productsSpecParams.BrandId == P.ProductBrandId) &&
                (!productsSpecParams.TypeId.HasValue || productsSpecParams.TypeId == P.ProductTypeId ))
        {
            AddInclude(P => P.ProductType);
            AddInclude(P => P.ProductBrand);
            ApplyPagination(productsSpecParams.PageSize * (productsSpecParams.PageIndex - 1) , productsSpecParams.PageSize);
            AddOrderBy(P => P.Name);
            if (!string.IsNullOrEmpty(productsSpecParams.Sort))
            {
                switch (productsSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
        }

        public ProductsWithTypeAndBrandsSpecification(int id) : base(P => P.Id == id)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }

    }
}
