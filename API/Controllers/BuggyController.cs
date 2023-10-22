using API.Errors;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _storeContext;
        public BuggyController(StoreContext storeContext)
        {
                _storeContext = storeContext;
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _storeContext.Products.Find(5);          
            return Ok(product?.ToString());
        }


        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _storeContext.Products.Find(5);
            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
