using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Todo.Contracts.Exceptions;

namespace Todo.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            try
            {
                Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

                if (exception is not CustomException customException)
                {
                    return Problem();
                }

                var statusCode = customException?.InnerException?.Message;

                return Problem(title: "Error", detail: customException?.Message, statusCode: int.Parse(statusCode));
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
