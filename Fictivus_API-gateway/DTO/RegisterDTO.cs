using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fictivus_API_gateway.DTO
{
    public class RegisterDTO
    {
        #region fields
        #endregion

        #region constructors
        //empty constructor for JSON
        public RegisterDTO()
        {

        }

        public RegisterDTO(string username, string emailAdress, string password, string confirmPassword)
        {
            Username = username;
            EmailAdress = emailAdress;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
        #endregion

        #region properties

        public string Username { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        #endregion


    }
}
