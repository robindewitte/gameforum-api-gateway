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
    [Route("api/write")]
    [ApiController]
    public class TopicWriteController : Controller
    {
        //moet niet anonymous zijn in toekomst
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("writeMock")]
        public async Task<ActionResult<string>> WriteMock(TopicDTO topicDTO)
        {

            Messaging.MessageSender.SendMessage(topicDTO);
            

            return "verzonden";
            
        }

        // log de tijd in deze
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("writeMockCheck")]
        public async Task<ActionResult<string>> WriteMockCheck(TopicDTO topicDTO)
        {
            IFlurlResponse response = await $"{Constants.TopicApiUrl}/api/search/writemock".PostJsonAsync(topicDTO);

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
                return "geslaagd";
            }

            return "verzonden";

        }

        //moet niet anonymous zijn in toekomst
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("deleteMock")]
        public async Task<ActionResult<string>> DeleteMocke(TopicDTO topicDTO)
        {
            //moet DTO kunnen verzenden
            /*
            Messaging.MessageSender.SendMessage()
            */

            return "verzonden";

        }
    }
}
