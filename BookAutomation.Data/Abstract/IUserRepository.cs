using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Data.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetByUserNameAsync(string userName);
        Task<List<User>> GetByFirstNameAsync(string firstName);
        Task<List<User>> GetByLastNameAsync(string lastName);
    }
}
