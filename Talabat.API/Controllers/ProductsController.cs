using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.API.DTOs;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications;
using Talabat.BLL.Specifications.ProductsSpecification;
using Talabat.DAL.Entities;

namespace Talabat.API.Controllers
{
    public class ProductsController : BaseAPIController
    {
        private readonly IGenaricRepository<Product> productsRepo;
        private readonly IGenaricRepository<ProductBrand> brandsRepo;
        private readonly IGenaricRepository<ProductType> typeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenaricRepository<Product> productsRepo,
            IGenaricRepository<ProductBrand> brandsRepo, IGenaricRepository<ProductType> typeRepo, IMapper mapper)
        {
            this.productsRepo=productsRepo;
            this.brandsRepo=brandsRepo;
            this.typeRepo=typeRepo;
            this.mapper=mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<Pagination<ProductToReturnDtos>>>> GetProducts([FromQuery] ProductsSpecParams productsSpecParams)
        {

            var spec = new ProductsWithTypeAndBrandsSpecification(productsSpecParams);
            
            var countSpec = new ProductWithFiltersForCountSpecification(productsSpecParams);
            
            var totalItems = await productsRepo.GetCountAsync(countSpec);
            
            var products = await productsRepo.GetAllWithSpecAsync(spec);

            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDtos>>(products);

            if (data == null)
                return NotFound(new ApiResponse(404));
          
            return Ok(new Pagination<ProductToReturnDtos>(productsSpecParams.PageIndex, productsSpecParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDtos>> GetProduct(int id)
        {
            var spec = new ProductsWithTypeAndBrandsSpecification(id);
            var products = await productsRepo.GetEntityWithSpecAsync(spec);
            var productDto = mapper.Map<Product, ProductToReturnDtos>(products);
            if (productDto == null)
                return NotFound(new ApiResponse(404));
            return Ok(productDto);
        }

        [HttpGet("brands")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await brandsRepo.GetAllAsync();
            var productBrandDto = brands;
            if (productBrandDto == null)
                return NotFound(new ApiResponse(404));
            return Ok(productBrandDto);

        }

        [HttpGet("types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetTypes()
        {
            var types = await typeRepo.GetAllAsync();
            var productTypeDto = types;
            if (productTypeDto == null)
                return NotFound(new ApiResponse(404));
            return Ok(productTypeDto);

        }
    }
}
