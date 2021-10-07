using Fictivus_API_gateway.DTO;
using Fictivus_API_gateway.Helper;
using Flurl.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fictivus_API_gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/search")]
    [ApiController]
    public class TopicSearchController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetTopicPostsByTerm")]
        public async Task<ActionResult<List<ResponseDTO>>> GetTopicPostsByTerm(SearchInTopicDTO search)
        {

            IFlurlResponse response = await $"{Constants.AccountApiUrl}/api/search/gettopicpostbyterm".PostJsonAsync(search);

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
                List<ResponseDTO> answer = (List<ResponseDTO>)await response.GetJsonListAsync();
                return answer;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetTopicPosts")]
        public async Task<ActionResult<List<ResponseDTO>>> GetTopicPosts(string topicTitle)
        {

            IFlurlResponse response = await $"{Constants.AccountApiUrl}/api/search/gettopicpostbyterm".PostJsonAsync(topicTitle);

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
                List<ResponseDTO> answer = (List<ResponseDTO>)await response.GetJsonListAsync();
                return answer;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetPostsByTerm")]
        public async Task<ActionResult<List<ResponseDTO>>> GetPostsByTerm(string searchTerm)
        {

            IFlurlResponse response = await $"{Constants.AccountApiUrl}/api/search/getpostsbyterm".PostJsonAsync(searchTerm);

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
                List<ResponseDTO> answer = (List<ResponseDTO>)await response.GetJsonListAsync();
                return answer;
            }
        }


    }
}
