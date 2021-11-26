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
        public async Task<ActionResult<ICollection<ResponseDTO>>> GetTopicPostsByTerm(SearchInTopicDTO search)
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/gettopicpostbyterm".PostJsonAsync(search);

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
                ICollection<ResponseDTO> answer = await response.GetJsonAsync<ICollection<ResponseDTO>>();
                return Ok(answer);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetTopicPostsBySubject")]
        public async Task<ActionResult<ICollection<ResponseDTO>>> GetTopicPosts(string subject)
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/gettopicpostsbysubject".PostJsonAsync(subject);

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
                ICollection<ResponseDTO> answer = await response.GetJsonAsync<ICollection<ResponseDTO>>();
                return Ok(answer);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetPostsByTerm/{searchTerm}")]
        public async Task<ActionResult<ICollection<ResponseDTO>>> GetPostsByTerm(string searchTerm)
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/getpostsbyterm/{searchTerm}".GetAsync();

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
               ICollection<ResponseDTO> answer = await response.GetJsonAsync<ICollection<ResponseDTO>>();
               return Ok(answer);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetPostsByUsername/{username}")]
        public async Task<ActionResult<ICollection<ResponseDTO>>> GetPostsByUsername(string username)
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/GetPostsByUsername/{username}".GetAsync();

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
                ICollection<ResponseDTO> answer = await response.GetJsonAsync<ICollection<ResponseDTO>>();
                return Ok(answer);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetPostsFromTopic/{topicTitle}")]
        public async Task<ActionResult<ICollection<ResponseDTO>>> GetPostsFromTopic(string topicTitle)
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/GetPostsFromTopic/{topicTitle}".GetAsync();

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
                ICollection<ResponseDTO> answer = await response.GetJsonAsync<ICollection<ResponseDTO>>();
                return Ok(answer);
            }
        }

        #region meme

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetMemeTopics")]
        public async Task<ActionResult<ICollection<TopicDTO>>> GetMemeTopics()
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/GetMemeTopics".GetAsync();

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
                ICollection<TopicDTO> answer = await response.GetJsonAsync<ICollection<TopicDTO>>();
                return Ok(answer);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetMemePostsBySearchTerm/{term}")]
        public async Task<ActionResult<ICollection<ResponseDTO>>> GetMemePostsBySearchTerm(string term)
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/GetMemePostsBySearchTerm/{term}".GetAsync();

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
                ICollection<ResponseDTO> answer = await response.GetJsonAsync<ICollection<ResponseDTO>>();
                return Ok(answer);
            }
        }

        #endregion

        #region discussion
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetDiscussionTopics")]
        public async Task<ActionResult<ICollection<TopicDTO>>> GetDiscussionTopics()
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/GetDiscussionTopics".GetAsync();

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
                ICollection<TopicDTO> answer = await response.GetJsonAsync<ICollection<TopicDTO>>();
                return Ok(answer);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetDiscussionPostsBySearchTerm/{term}")]
        public async Task<ActionResult<ICollection<ResponseDTO>>> GetDiscussionPostsBySearchTerm(string term)
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/GetDiscussionPostsBySearchTerm/{term}".GetAsync();

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
                ICollection<ResponseDTO> answer = await response.GetJsonAsync<ICollection<ResponseDTO>>();
                return Ok(answer);
            }
        }

        #endregion
        #region modReleases
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetModReleasesTopics")]
        public async Task<ActionResult<ICollection<TopicDTO>>> GetModReleasesTopics()
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/GetModReleasesTopics".GetAsync();

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
                ICollection<TopicDTO> answer = await response.GetJsonAsync<ICollection<TopicDTO>>();
                return Ok(answer);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetModReleasesPostsBySearchTerm/{term}")]
        public async Task<ActionResult<ICollection<ResponseDTO>>> GetModReleasesPostsBySearchTerm(string term)
        {

            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/GetModReleasesPostsBySearchTerm/{term}".GetAsync();

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
                ICollection<ResponseDTO> answer = await response.GetJsonAsync<ICollection<ResponseDTO>>();
                return Ok(answer);
            }
        }

        #endregion
    }
}
