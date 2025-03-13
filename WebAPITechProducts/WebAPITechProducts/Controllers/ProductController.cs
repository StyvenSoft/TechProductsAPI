using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITechProducts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAPITechProducts.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbtechProductsContext _dbtechProductsContext;
        public ProductController(DbtechProductsContext dbtechProductsContext)
        {
            _dbtechProductsContext = dbtechProductsContext;
        }

        // Endpoint obtener productos
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var list = await _dbtechProductsContext.Products.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = list });
        }
    }
}
