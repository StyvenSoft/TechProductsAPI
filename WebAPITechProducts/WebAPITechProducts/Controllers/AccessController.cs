using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITechProducts.Custom;
using WebAPITechProducts.Models;
using WebAPITechProducts.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebAPITechProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly DbtechProductsContext _dbtechProductsContext;
        private readonly Utilities _utilities;
        public AccessController(DbtechProductsContext dbtechProductsContext, Utilities utilities)
        {
            _dbtechProductsContext = dbtechProductsContext;
            _utilities = utilities;
        }

        [HttpPost]
        [Route("Signin")]
        public async Task<IActionResult> Signin(UserDTO _object)
        {
            var modelUser = new User
            {
                FullName = _object.FullName,
                Email = _object.Email,
                Passwd = _utilities.EncryptSHA256(_object.PassWd)
            };

            await _dbtechProductsContext.Users.AddAsync(modelUser);
            await _dbtechProductsContext.SaveChangesAsync();

            if (modelUser.UserId != 0)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSucsess = true });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }
        }
    }
}
