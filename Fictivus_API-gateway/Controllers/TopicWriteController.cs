﻿using Fictivus_API_gateway.DTO;
using Fictivus_API_gateway.Helper;
using Flurl.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Principal;

namespace Fictivus_API_gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/write")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class TopicWriteController : Controller
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("posttopic")]
        public async Task<ActionResult<bool>> PostTopic(TopicDTO topicDTO)
        {
            IFlurlResponse response = await $"{Constants.WriteApiUrl}/api/write/PostTopic".PostJsonAsync(topicDTO);

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
                bool answer = response.GetJsonAsync<bool>().Result;
                return Ok(answer);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("postresponse")]
        public async Task<ActionResult<bool>> PostResponse(ResponseDTO responseDTO)
        {
            IFlurlResponse response = await $"{Constants.WriteApiUrl}/api/write/PostResponse".PostJsonAsync(responseDTO);

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
                bool answer = response.GetJsonAsync<bool>().Result;
                return Ok(answer);
            }

        }

        //moet straks weer parameter hebben
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("deletetopic")]
        public async Task<ActionResult<bool>> DeleteTopic(TopicDTO topicDTO)
        {
            IFlurlResponse response = await $"{Constants.WriteApiUrl}/api/write/DeleteTopic".PostJsonAsync(topicDTO);

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
                bool answer = response.GetJsonAsync<bool>().Result;
                return Ok(answer);
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("deleteresponse")]
        public async Task<ActionResult<bool>> DeleteResponse(ResponseDTO responseDTO)
        {
            IFlurlResponse response = await $"{Constants.WriteApiUrl}/api/write/DeleteResponse".PostJsonAsync(responseDTO);

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
                bool answer = response.GetJsonAsync<bool>().Result;
                return Ok(answer);
            }
        }
        

        public bool ValidateToken (string token)
        {
            token = token.Substring(7);
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            try
            {
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }      
        }

        public bool ValidateUsername(string token, string username)
        {
            token = token.Substring(7);
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == "sub").Value;
            if(stringClaimValue == username)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "Test.com",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKey")) // The same key as the one that generate the token
            };
        }
    }
}
