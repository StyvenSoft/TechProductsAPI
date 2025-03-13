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

        // Endpoint de registro
        [HttpPost]
        [Route("signin")]
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

        // Endpoint iniciar sesión
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO _object)
        {
            var userFound = await _dbtechProductsContext.Users
                .Where(u => u.Email == _object.Email
                    && u.Passwd == _utilities.EncryptSHA256(_object.Passwd))
                .FirstOrDefaultAsync();
            if (userFound == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilities.GenerateJWT(userFound) });
            }
        }
    }
}
