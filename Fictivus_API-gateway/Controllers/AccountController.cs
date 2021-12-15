using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Fictivus_API_gateway.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Fictivus_API_gateway.DTO;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Security.Principal;

namespace Fictivus_API_gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [Authorize(AuthenticationSchemes = "")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("login")]
        public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
        {
            
            IFlurlResponse response = await $"{Constants.AccountApiUrl}/api/account/login".PostJsonAsync(loginDTO);

            if (response.StatusCode >= 500)
            {
                return StatusCode(500);
            }
            else if (response.StatusCode >= 400)
            {
                return StatusCode(400);
            }
            else
            {
                string answer = await response.GetStringAsync();
                ValidateToken(answer);
                return answer;
            }
        }



        //bekijk hoe ik de value wil doorgeven voor deze methode

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("register")]
        public async Task<ActionResult<string>> Register(RegisterDTO registerDTO)
        {
            IFlurlResponse response = await $"{Constants.AccountApiUrl}/api/account/register".PostJsonAsync(registerDTO);
            if (response.StatusCode >= 500)
            {
                return StatusCode(500);
            }
            else if (response.StatusCode >= 400)
            {
                return StatusCode(400);
            }
            else
            {
                string answer = await response.GetStringAsync();
                return answer;
            }
        }
    }
}
