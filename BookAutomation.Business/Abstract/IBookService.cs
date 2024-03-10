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
    public interface IBookService : IService<BookRO, BookDTO>, IResponser<Book, BookRO>, IValidator<Book>
    {
        Task<List<BookRO>> GetByNameAsync(string name);
        Task<List<BookRO>> GetByAuthorAsync(string author);
        Task<List<BookRO>> GetByGenreAsync(string genre);
    }
}
