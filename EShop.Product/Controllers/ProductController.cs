using EShop.Product.Core.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace EShop.Product.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductController(IServiceManager serviceManager, IHttpContextAccessor contextAccessor)
        {
            _serviceManager = serviceManager;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts(string? searchTerm = null, int pageNumber = 1, int pageSize = 20)
        {
            try
            {
                var results = await _serviceManager.Product.GetProducts(searchTerm, pageNumber, pageSize);
                return Ok(results);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
