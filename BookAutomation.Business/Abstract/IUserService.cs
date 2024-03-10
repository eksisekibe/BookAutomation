using BookAutomation.Business.DTOs;
using BookAutomation.Business.ROs;
using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Abstract
{
    public interface IUserService : IService<UserRO, UserDTO>, IResponser<User, UserRO>, IValidator<User>
    {
        Task<UserRO> GetByUserNameAsync(string userName);
        Task<List<UserRO>> GetByFirstNameAsync(string firstName);
        Task<List<UserRO>> GetByLastNameAsync(string lastName);
    }
}
