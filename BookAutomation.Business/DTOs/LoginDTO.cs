using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.DTOs
{
    /// <summary>
    /// Defines User Login Data Contract
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Represents Unique Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Represents User Password
        /// </summary>
        public string Password { get; set; }
    }
}
