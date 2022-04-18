using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("V1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            //Stop in 0:24
            //It gets the user from the repository
            var user = UserRepository.Get(model.UserName, model.Password);

            if (user == null)
                return NotFound(new { message = "Invalid user or passworkd." });

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            //It returns the data
            return new
            {
                user = user,
                token = token
            };
        }
    }
}