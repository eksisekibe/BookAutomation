using BookAutomation.Business.DTOs;
using BookAutomation.Business.ROs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Abstract
{
    public interface IAuthorizationService
    {
        Task<LoginRO> Login(LoginDTO loginDTO);
    }
}
