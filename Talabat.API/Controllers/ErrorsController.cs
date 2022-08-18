using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.Errors;

namespace Talabat.API.Controllers
{
    [Route("errors/code")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController :BaseAPIController
    {

        public ActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse (code));
        }

    }
}
