using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Talabat.API.Errors;
using Talabat.BLL.Interfaces;
using Talabat.DAL;
using Talabat.DAL.Entities;

namespace Talabat.API.Controllers
{

    public class BuggyController: BaseAPIController
    {
        private readonly StoreContext context;
        public BuggyController(StoreContext context)
        { 
            this.context=context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var product = context.products.Find(100);
            if(product == null)
            return NotFound(new ApiResponse(404));
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
          
            return BadRequest(new ApiResponse(400));
        }
    }
}
