using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Utils.JWT.Abstract
{
    public interface ITokenHelper
    {
        string CreateToken(User user);
    }
}
