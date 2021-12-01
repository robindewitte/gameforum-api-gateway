using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fictivus_API_gateway.DTO
{
    public class LoginDTO
    {
        #region fields
        #endregion

        #region constructors
        //empty constructor for JSON
        public LoginDTO()
        {

        }

        public LoginDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
        #endregion

        #region properties

        public string Username { get; set; }
        public string Password { get; set; }
        #endregion
    }
}
