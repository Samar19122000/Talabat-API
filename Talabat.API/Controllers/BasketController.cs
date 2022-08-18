using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Talabat.BLL.Interfaces;
using Talabat.DAL.Entities;

namespace Talabat.API.Controllers
{
    public class BasketController : BaseAPIController
    {
        private readonly IBasketRepository basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this.basketRepository=basketRepository;
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string basketid)
        {
            var basket = await basketRepository.GetCustomerBasket(basketid);

            return Ok(basket ?? new CustomerBasket(basketid));
        }


        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdatetBasket(CustomerBasket basket)
        {
            var CustomerBasket = await basketRepository.UpdateCustomerBasket(basket);

            return Ok(CustomerBasket);
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string basketId)
        {
            return await basketRepository.DeleteCustomerBasket(basketId); 
        }
 










    }
}
