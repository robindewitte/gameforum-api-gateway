using Fictivus_API_gateway.DTO;
using Fictivus_API_gateway.Helper;
using Flurl.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fictivus_API_gateway.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/write")]
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
            Messaging.MessageSender.SendMessage("posttopic", JsonConvert.SerializeObject(topicDTO));
            return true;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("postresponse")]
        public async Task<ActionResult<bool>> PostResponse(ResponseDTO responseDTO)
        {
            Messaging.MessageSender.SendMessage("postresponse", JsonConvert.SerializeObject(responseDTO));
            return true;
        }

        //moet straks weer parameter hebben
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("deletetopic")]
        public async Task<ActionResult<bool>> DeleteTopic()
        {
            TopicDTO topicDTO = new TopicDTO("uh", "ah", DateTime.Now, "argl");
            Messaging.MessageSender.SendMessage("deletetopic", JsonConvert.SerializeObject(topicDTO));
            return true;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("deleteresponse")]
        public async Task<ActionResult<bool>> DeleteResponse(ResponseDTO responseDTO)
        {
            Messaging.MessageSender.SendMessage("deleteresponse", JsonConvert.SerializeObject(responseDTO));
            return true;
        }


    }
}
