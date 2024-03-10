using BookAutomation.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.ROs
{
    public class LoginRO
    {
        public UserRO User { get; set; }
        public TokenRO Token { get; set; }
    }
}
