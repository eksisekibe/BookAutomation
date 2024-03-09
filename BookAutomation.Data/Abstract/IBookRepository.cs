using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Data.Abstract
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetByNameAsync(string name);
        Task<List<Book>> GetByAuthorAsync(string author);
        Task<List<Book>> GetByGenreAsync(string genre);
        Task<List<Book>> GetCategoryBooksAsync(int categoryId);
        Task<string> GetLastModifiedUserNameAsync(int bookId);
        Task<User> GetLastModifiedByAsync(int bookId);
    }
}
