using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)] // Swagger render etmeye çalışırken dinamik olak Code'u render edemiyor bu yüzden swagger hata veriyordu. Bunun için bu apiyi ignore ettik.
    public class ErrorController : BaseApiController
    {
        public IActionResult Index(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
