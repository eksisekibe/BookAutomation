using BookAutomation.Data.Abstract;
using BookAutomation.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Data.Concrete
{
    public class UserRepository : PgGenericRepository<User>, IUserRepository
    {
        public UserRepository(PostgreSqlContext context) : base(context)
        {
        }

        public async Task<List<User>> GetByFirstNameAsync(string firstName)
        {
            return await _context.Users.Where(l => l.FirstName.ToLower().StartsWith(firstName.ToLower()) || l.FirstName.ToLower().Contains(firstName.ToLower())).ToListAsync();
        }

        public async Task<List<User>> GetByLastNameAsync(string lastName)
        {
            return await _context.Users.Where(l => l.LastName.ToLower().StartsWith(lastName.ToLower()) || l.LastName.ToLower().Contains(lastName.ToLower())).ToListAsync();
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users.Where(l => l.Username == userName).FirstOrDefaultAsync();
        }
    }
}
