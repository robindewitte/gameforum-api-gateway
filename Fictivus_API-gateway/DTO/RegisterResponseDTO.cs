using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fictivus_API_gateway.DTO
{
    public class RegisterResponseDTO
    {
        #region fields

        #endregion

        #region constructors
        //empty constructor for JSON
        public RegisterResponseDTO()
        {

        }

        public RegisterResponseDTO(string response)
        {
            this.Response = response;
        }
        #endregion

        #region properties
        public string Response { get; set; }
        #endregion
    }
}
